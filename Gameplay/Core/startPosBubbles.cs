using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPosBubbles : MonoBehaviour
{
    private bool wasStand = false;
    void Start()
    {
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(1375f, -20.15f, 0);
    }

    void Update()
    {
    	if(!wasStand){
	        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(1375f, -20.15f, 0);
    		wasStand = !wasStand;
    	}
    }
}
