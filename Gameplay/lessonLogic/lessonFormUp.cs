using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lessonFormUp : MonoBehaviour
{
	public GameObject banner1;
	public GameObject banner2;
  private int clickedCount = 0;

  void Start()
  {
 		banner1.transform.SetSiblingIndex(1000);
   	banner2.transform.SetSiblingIndex(0);
   	print(banner1.transform.GetSiblingIndex());
   	print(banner2.transform.GetSiblingIndex());
  }

  void Update()
  {
      if(Input.GetMouseButtonDown(0))
      {
        if(clickedCount == 0)
        {
          Destroy(banner1);
          banner2.transform.SetSiblingIndex(1000);
        }
        if(clickedCount == 1)
          Destroy(banner2);
        clickedCount++;
        }
    }
}
