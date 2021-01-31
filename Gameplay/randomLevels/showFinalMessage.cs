using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class showFinalMessage : MonoBehaviour
{
	public GameObject finalBanner;
    void Start()
    {
        finalBanner = GameObject.Find("FinalBanner");
    }

    void Update()
    {
        if(victory_container.is_victory){
            if(RandomTransitionContainer.available_scenes.Count() == 0 && RandomTransitionContainer.randomTransition && finalBanner != null && RandomTransitionContainer.lastLevelWasStart){ 
                Destroy(GameObject.Find("victory_back"));
                finalBanner.transform.SetSiblingIndex(2100);
            }
            else
                gameObject.transform.SetSiblingIndex(2000);

            if(RandomTransitionContainer.available_scenes.Count() == 0)
                RandomTransitionContainer.lastLevelWasStart = true;
    	}
    }
}
