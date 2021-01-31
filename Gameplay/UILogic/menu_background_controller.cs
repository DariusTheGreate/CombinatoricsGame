using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_background_controller : MonoBehaviour
{
	public GameObject menu_init;
	public GameObject menu_res;
	public GameObject blure;
	
    void Start()
    {
    }

    void Update()
    {
        if(RandomTransitionContainer.isRandomTypeAvailable)
    	{
    		blure.SetActive(false);
    	}
    	else
    	{
    	}       
    }
}
