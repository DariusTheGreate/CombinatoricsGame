using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    void Update()
    {
        if(RandomTransitionContainer.LivesCount <= 0)
        {
        	gameObject.transform.SetSiblingIndex(1050);
        }
    }
}
