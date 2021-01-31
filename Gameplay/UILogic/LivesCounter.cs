using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    void Start()
    {
        var sentence = " попытки";
        if(RandomTransitionContainer.LivesCount == 0)
            sentence = " попыток";
        if(RandomTransitionContainer.LivesCount == 1)
            sentence = " попытка";
            
        gameObject.GetComponent<Text>().text = "осталось " + RandomTransitionContainer.LivesCount.ToString() + sentence; 
    }
}
