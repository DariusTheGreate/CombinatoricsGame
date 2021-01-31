using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float FillSpeed = 0.5f;
    private float value = 0.0f;
    public string mess;
    public bool menuBar = false;
    private GameObject BAR;

    void Start()
    {
    	BAR = GameObject.Find("BAR");
    	var counter = GameObject.Find("randomLevelsCounter");
    	if(counter != null)
	    	counter.GetComponent<Text>().text = mess + " " + PlayerPrefs.GetInt("LevelRecord");
    	value = ((float)PlayerPrefs.GetInt("LevelRecord"))/(RandomTransitionContainer.sceneCount-1);
    }

    void Update()
    {   
    	value = ((float)(PlayerPrefs.GetInt("LevelRecord")))/(RandomTransitionContainer.sceneCount);
    	var bar_value = BAR.GetComponent<RectTransform>().localScale;
    	BAR.GetComponent<RectTransform>().localScale = new Vector3(value, bar_value.y, bar_value.z);
        print((value * 100f).ToString() + " %");
    	GameObject.Find("BAR_TEXT").GetComponent<Text>().text = (value * 100f).ToString() + " %"; //(PlayerPrefs.GetInt("LevelRecord")).ToString() + " из " + (RandomTransitionContainer.sceneCount - 1).ToString();
    	if(PlayerPrefs.GetInt("LevelRecord") == 9 && menuBar){
    		BAR.GetComponent<RectTransform>().localScale = new Vector3(1, bar_value.y, bar_value.z);
    		GameObject.Find("BAR_TEXT").GetComponent<Text>().text = "100 %"; //(PlayerPrefs.GetInt("LevelRecord")).ToString() + " из " + (RandomTransitionContainer.sceneCount - 1).ToString();
    	}
    }
}
