using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttainmentsShower : MonoBehaviour
{

	void Start()
	{
		foreach(var i in AttainmentController.attainments){
			var obj = GameObject.Find(i);
			if(obj != null)
				obj.transform.SetSiblingIndex(1000);
		}
	}
}
