using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class spot_drop : MonoBehaviour, IDropHandler
{
	private GameObject dropped;
	private Vector3 start_dropped;
	public bool empty = true;
	private bool dropped_was_created = false;

	void Start()
	{
		start_dropped = GetComponent<RectTransform>().anchoredPosition;
	}

   	public void OnDrop(PointerEventData eventData)
    {

        if(eventData.pointerDrag != null && empty){

            eventData.pointerDrag.GetComponent<drop_item>().endDrag = false;
        	eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        	
            dropped = eventData.pointerDrag;
            dropped_was_created = true;
        	empty = false;
        }
    }

    void Update()
    {
    	if(dropped_was_created && dropped.GetComponent<RectTransform>().anchoredPosition != new Vector2(start_dropped.x, start_dropped.y))
    		empty = true;
    }
}
