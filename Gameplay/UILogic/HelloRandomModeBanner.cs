using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloRandomModeBanner : MonoBehaviour
{
    public GameObject lesson_banner_0;
    public GameObject lesson_banner_1;
    private int clickCount = 0;
    public bool start_work;

    void Start()
    {
        lesson_banner_0.transform.SetSiblingIndex(0);
        lesson_banner_1.transform.SetSiblingIndex(0);
    	if(!PlayerPrefs.HasKey("wasShowed"))
	    	gameObject.transform.SetSiblingIndex(1000); 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !PlayerPrefs.HasKey("wasShowed"))
        {
    		gameObject.transform.SetSiblingIndex(0);
    		PlayerPrefs.SetString("wasShowed", "wasShowed");
    	}
        else if(!PlayerPrefs.HasKey("wasLearnedRandoms"))
        {
            if(PlayerPrefs.HasKey("wasShowed")){
                if(lesson_banner_0 != null)
                    lesson_banner_0.transform.SetSiblingIndex(1000);
                start_work = true;
            }
            else
                start_work = false;

            if (start_work && Input.GetMouseButtonDown(0)){
                if(clickCount == 0)
                    Destroy(lesson_banner_0);
                if(clickCount == 1){
                    Destroy(lesson_banner_1);
                }
                
                clickCount++;
                if(clickCount == 1)
                    lesson_banner_1.transform.SetSiblingIndex(1000);
                if(clickCount == 2)
                    PlayerPrefs.SetString("wasLearnedRandoms","wasLearnedRandoms");
            } 
        }
    }
}
