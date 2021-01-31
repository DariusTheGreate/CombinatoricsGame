using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryKiller : MonoBehaviour
{
    void Awake()
    {
    	var strTriger = "kill me first";
    	if(!PlayerPrefs.HasKey(strTriger))
        	Kill(strTriger);

    }
    void Kill(string str_)
    {
    	PlayerPrefs.DeleteAll();
      PlayerPrefs.DeleteKey("LevelRecord");
    	PlayerPrefs.SetString(str_, str_);
    	PlayerPrefs.SetInt("M", 0);
    }
    void clearLevels()
    {
      PlayerPrefs.DeleteKey("wasLearnedRandoms");
      PlayerPrefs.DeleteKey("saved_level ");

      for (int i = 0; i < LevelsContainer.maxLevelCounter; i++)
      {
          PlayerPrefs.DeleteKey("saved_level " + i.ToString());
      }
      
      for(int i = 0; i < LevelsContainer.maxLevelCounter; i++)
      {
      		PlayerPrefs.DeleteKey("level" + i.ToString());
      }

      for(int i = 0; i < AttainmentController.maxAttCount; i++)
      {
      		PlayerPrefs.DeleteKey("att" + i.ToString());
      }
    }

    void DeletePassedScenesAndMoneyValue()
    {
        foreach(var scn in shareMoneyAmount.passed_scenes)
        {
            PlayerPrefs.DeleteKey(scn);
        }
        
        PlayerPrefs.DeleteKey("M");
    }

    void SaveLevels()
    {
    	for (int i = 0; i < LevelsContainer.passed_levels.Count; i++)
  		{
      		PlayerPrefs.SetString(LevelsContainer.passed_levels[i], LevelsContainer.passed_levels[i]);
  		}
    }

    void OnApplicationQuit()
    {
    	SaveLevels();
    }
}
