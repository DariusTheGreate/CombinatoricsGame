using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryAttainments : MonoBehaviour
{
	void Awake()
	{
		for(int i = 0; i < AttainmentController.maxAttCount; i++){
			AttainmentController.attainments.Add(PlayerPrefs.GetString("att" + i.ToString()));
		}
	}

    void Update()
    {
		foreach(var i in AttainmentController.attainments)
			PlayerPrefs.SetString(i,i);
    }
}
