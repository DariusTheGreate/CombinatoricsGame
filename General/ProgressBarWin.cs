using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarWin : MonoBehaviour
{
    public float FillSpeed = 0.5f;
    private float value = 0.0f;
    public string mess;
    public bool menuBar = false;
    private GameObject BAR;
    private bool wasIncremented = false;
    void Start()
    {
    	BAR = GameObject.Find("BARWIN");
    }

    void Update()
    {
    	if(wasIncremented)
    		return;
        value = ((float)(PlayerPrefs.GetInt("LevelRecord") + 1))/(RandomTransitionContainer.sceneCount);
    	var bar_value = BAR.GetComponent<RectTransform>().localScale;
    	BAR.GetComponent<RectTransform>().localScale = new Vector3(value, bar_value.y, bar_value.z);
    	GameObject.Find("BARWIN_TEXT").GetComponent<Text>().text = (value * 100f).ToString() + " %"; //(PlayerPrefs.GetInt("LevelRecord")).ToString() + " из " + (RandomTransitionContainer.sceneCount - 1).ToString();
    	if(PlayerPrefs.GetInt("LevelRecord") == 9 && menuBar){
    		BAR.GetComponent<RectTransform>().localScale = new Vector3(1, bar_value.y, bar_value.z);
    		GameObject.Find("BARWIN_TEXT").GetComponent<Text>().text = "100 %"; //(PlayerPrefs.GetInt("LevelRecord")).ToString() + " из " + (RandomTransitionContainer.sceneCount - 1).ToString();
    	}
    	wasIncremented = true;
    }
}
