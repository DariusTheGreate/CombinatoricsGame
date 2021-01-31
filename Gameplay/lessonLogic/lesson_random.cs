using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson_random : MonoBehaviour
{
    /*public GameObject banner_button;
    private bool toStart = false;
    private bool toTarget = true;
    public bool start_work;
    public GameObject target;
    public GameObject lesson_banner_0;
    public GameObject lesson_banner_1;
    private int clickCount = 0;
    void Start()
    {
    }

    void Update()
    {
    	//if(PlayerPrefs.HasKey("wasLearnedRandoms"))
    	//	return;
    	print("ssds");
        if(PlayerPrefs.HasKey("wasShowed")){//GameObject.Find("hellorandomModeBanner").transform.GetSiblingIndex() < 10){
            if(lesson_banner_0 != null)
                lesson_banner_0.transform.SetSiblingIndex(1000);
            start_work = true;
        }
        else
            start_work = false;

        if (start_work && Input.GetMouseButtonDown(0)){// && Vector3.Distance(Input.mousePosition, banner_button.transform.position) > 100){
	        if(clickCount == 0)
                Destroy(lesson_banner_0);
            if(clickCount == 1){
                Destroy(lesson_banner_1);
                gameObject.GetComponent<CanvasGroup>().alpha = 0f;
                gameObject.transform.SetSiblingIndex(0);
            }
            
            clickCount++;
            if(clickCount == 1)
                lesson_banner_1.transform.SetSiblingIndex(1000);
        } 
        //PlayerPrefs.SetString("wasLearnedRandoms","wasLearnedRandoms");
    }*/
}
