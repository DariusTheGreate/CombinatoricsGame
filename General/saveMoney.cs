using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveMoney : MonoBehaviour
{
	void Start()
	{
		shareMoneyAmount.number = PlayerPrefs.GetInt("M");
	}

	void Update()
    {
    	PlayerPrefs.SetInt("M", shareMoneyAmount.number);
    	SavePassedScenes();
    }

    void SavePassedScenes()
    {
    	foreach(var scn in shareMoneyAmount.passed_scenes)
    	{
    		PlayerPrefs.SetString(scn, scn);
    	}
    }

    void DeletePassedScenes()
    {
        foreach(var scn in shareMoneyAmount.passed_scenes)
        {
            PlayerPrefs.DeleteKey(scn);
        }
        PlayerPrefs.DeleteKey("M");
    }
}

