using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class menu_controller : MonoBehaviour
{
    void Start ()
    {
    	LevelsContainer.passed_levels = LoadLevels();
      StandColor();
    }

    void SaveLevelRecord()
    {
      PlayerPrefs.SetInt("recordAmount", RandomTransitionContainer.LevelRecord);
    }

    void StandColor()
    {
      var bubble = GameObject.Find("bubble_container");
      foreach(Transform i in bubble.transform)
      {
        int level_num = 0;
        int.TryParse(i.name, out level_num);
        int scene_num = level_num + 1;
        if(LevelsContainer.passed_levels.Contains("saved_level " + scene_num.ToString())){
          var red_b = Resources.Load<Sprite>("red_bubble");
          i.gameObject.GetComponent<Image>().sprite = red_b;       
        }
      }
    }

    List<string> LoadLevels()
    {
    	List<string> res = new List<string>();
    	res.Add("saved_level 2");
    	for (int i = 3; i < LevelsContainer.maxLevelCounter; i++)
  		{
        if(PlayerPrefs.HasKey("saved_level " + i.ToString()))
          res.Add(PlayerPrefs.GetString("saved_level " + i.ToString()));
  		}
  		return res;
    }

    void clearLevels()
    {
      PlayerPrefs.DeleteKey("saved_level ");
      for (int i = 0; i < LevelsContainer.maxLevelCounter; i++)
      {
          PlayerPrefs.DeleteKey("saved_level " + i.ToString());
      }
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
      SaveLevelRecord();
    }
}
