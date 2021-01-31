using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowBanner : MonoBehaviour
{
    public GameObject window;

    void Start()
    {
        gameObject.transform.SetSiblingIndex(1000);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            gameObject.transform.SetSiblingIndex(0);
    }
}
