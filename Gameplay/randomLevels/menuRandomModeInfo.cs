using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuRandomModeInfo : MonoBehaviour
{
    void Update()
    {
      	if(RandomTransitionContainer.isRandomTypeAvailable && !PlayerPrefs.HasKey("MenuRandomInfoBannerWasShowed"))
    	{
    		StartCoroutine(waiter());
    		PlayerPrefs.SetString("MenuRandomInfoBannerWasShowed", "MenuRandomInfoBannerWasShowed");
    	}   
    }

    IEnumerator waiter()
	{
	    yield return new WaitForSeconds(1);
		transform.SetSiblingIndex(1005);
	    yield return new WaitForSeconds(4);
    	transform.SetSiblingIndex(0);
	}
}
