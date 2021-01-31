using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class drop_item : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private float speed = 1500;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform startTransform;
    public Vector3 startPosition;
    public bool endDrag = false;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    void Update()
    {
        if(endDrag && transform.position != startPosition)
            StartCoroutine(MoveTowardsTarget());
    }
 
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup  = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        endDrag = false;
        gameObject.transform.SetSiblingIndex(1000);
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        endDrag = false;
        if(eventData != null)
	        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endDrag = true;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (eventData != null)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current) { pointerId = -1, };
            pointerData.position = eventData.position;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);
            foreach (RaycastResult result in results)
            {
                ///print(result.gameObject.tag);
                //if (result.gameObject.tag.Equals("test_spot_tag") && result.gameObject != this.gameObject)
                //{
                if(result.gameObject != this.gameObject){
                    var scr = result.gameObject.GetComponent<item_drop>();
                    if(scr != null && result.gameObject.GetComponent<item_drop>().enabled)
                        result.gameObject.GetComponent<item_drop>().OnDropF(this.gameObject);
                }
                if(result.gameObject.tag.Equals("answer_spot")){
                    var scr = result.gameObject.GetComponent<answer_drop>();
                    if(scr != null)
                        result.gameObject.GetComponent<answer_drop>().OnDropF(this.gameObject);
                }
                //}
            }
        }//if(transform.position != startPosition)
        //    MoveTowardsTarget();
    
    }

    private IEnumerator MoveTowardsTarget() {
        
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, startPosition, step);

        yield return new WaitForSeconds(0.1f);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(FormUpPressed.formUpPressed){
            var scr = gameObject.GetComponent<item_drop>();
            if(scr != null)
                scr.form_up_logic();
            LightsOff();
            FormUpPressed.formUpPressed = false;  

        }
    }

    public void LightsOff(){
        foreach (Transform child in GameObject.Find("Adaptability object").transform )
        {
            if(!(child.tag == "Pn" || child.tag == "Akn" || child.tag == "Untagged" || child.tag == "answer_spot"))
                child.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }
}
