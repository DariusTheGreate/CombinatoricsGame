using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class form_up_drag : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform startTransform;
    private Vector3 startPosition;
    public bool endDrag = false;

    void Start()
    {
    	canvas = GameObject.Find("Adaptability object");
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup  = GetComponent<CanvasGroup>();
    }

    private IEnumerator Wait() {
    	yield return new WaitForSeconds(0.5f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    	FormUpPressed.formUpPressed = true;
    	LightsOn();
    }
 
    public void LightsOn(){
    	foreach (Transform child in canvas.transform )
		{
			if(!(child.tag == "Pn" || child.tag == "Akn" || child.tag == "Untagged" || child.tag == "answer_spot"))
				child.GetComponent<CanvasGroup>().alpha = 0.5f;
		}
    }

    public void LightsOff(){
    	foreach (Transform child in canvas.transform )
		{
			if(!(child.tag == "Pn" || child.tag == "Akn" || child.tag == "Untagged" || child.tag == "answer_spot"))
				child.GetComponent<CanvasGroup>().alpha = 1f;
		}
    }
}
