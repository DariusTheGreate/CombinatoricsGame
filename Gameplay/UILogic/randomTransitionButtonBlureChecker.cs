using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTransitionButtonBlureChecker : MonoBehaviour
{
    void Update()
    {
        if(RandomTransitionContainer.isRandomTypeAvailable)
        	gameObject.GetComponent<CanvasGroup>().alpha = 1f;
    }
}
