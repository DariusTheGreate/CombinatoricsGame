using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class attainment : MonoBehaviour
{
    public string name_id_for_att;
    public AudioSource audio;
    
    void Start()
    {
        if(AttainmentController.attainments.Contains(name_id_for_att) || RandomTransitionContainer.randomTransition)
            return;
    	AttainmentController.attainments.Add(name_id_for_att);
    	StartCoroutine(waiter());
    }

    IEnumerator waiter()
	{
	    yield return new WaitForSeconds(1);
        audio.Play();
		transform.SetSiblingIndex(1005);
	    yield return new WaitForSeconds(4);
    	transform.SetSiblingIndex(0);
	}
}
