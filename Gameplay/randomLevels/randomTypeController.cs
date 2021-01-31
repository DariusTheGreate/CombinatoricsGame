using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTypeController : MonoBehaviour
{
	private GameObject random;
    
    void Start()
    {
    	random = GameObject.Find("random");
    }

    void Update()
    {
    	if(PlayerPrefs.HasKey("saved_level 13"))
    	{
    		RandomTransitionContainer.isRandomTypeAvailable = true;
    		random.SetActive(RandomTransitionContainer.isRandomTypeAvailable);
    	}
    			
    }
}
