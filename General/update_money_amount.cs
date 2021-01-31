using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class update_money_amount : MonoBehaviour
{
    void Start()
    {
    	for(int i = 0; i < LevelsContainer.maxLevelCounter; i++)
        {
        	shareMoneyAmount.passed_scenes.Add(PlayerPrefs.GetString("level" + i.ToString()));
        }
    }

    void Update()
    {
        transform.GetComponent<Text>().text = Convert.ToString(shareMoneyAmount.number);   
    }
}
