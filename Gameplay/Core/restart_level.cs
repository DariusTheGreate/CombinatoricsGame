using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class restart_level : MonoBehaviour
{
    private GameObject restartCounterMessage;
    
    void Start()
    {
        restartCounterMessage = GameObject.Find("restartCounterMessage");
        if(restartCounterMessage == null)
            return;
        var sentence = " попытки";
        if(RandomTransitionContainer.LivesCount == 0)
            sentence = " попыток";
        if(RandomTransitionContainer.LivesCount == 1)
            sentence = " попытка";
            
        restartCounterMessage.GetComponent<Text>().text = "осталось " + RandomTransitionContainer.LivesCount.ToString() + sentence;
    }

    public void restart()
    {
        if(!RandomTransitionContainer.randomTransition)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if(RandomTransitionContainer.LivesCount > 0)
        {
            RandomTransitionContainer.LivesCount--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
            print("CCAAAANNNTTT");
    }
}
