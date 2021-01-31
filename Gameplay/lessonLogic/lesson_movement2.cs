using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson_movement2 : MonoBehaviour
{
    private RectTransform start_trans;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public GameObject banner_button;
    public bool start_work;
    public GameObject target;
    public GameObject lesson_banner_1;
    public GameObject lesson_banner_2;
    public int speed= 100;
    public float pause = 0.2f;
    private int clickCount = 0;
    
    void Start()
    {
    	gameObject.GetComponent<CanvasGroup>().alpha = 0.0f;
    	//gameObject.SetActive(false);
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }

    void Update()
    {
        if(GameObject.Find("BannerMessage").transform.GetSiblingIndex() < 10 && GameObject.Find("n! Variant") != null && GameObject.Find("n! Variant").tag == "Pn")
            start_work = true;
        else
            start_work = false;

        if (start_work && Input.GetMouseButtonDown(0) && Vector3.Distance(Input.mousePosition, banner_button.transform.position) > 100){
            clickCount++;
            if(clickCount >= 1)
	            Destroy(gameObject);
        }

        if(start_work){
    		gameObject.GetComponent<CanvasGroup>().alpha = 0.5f;
    		//gameObject.SetActive(true);
            StartCoroutine(MoveTowardsTarget());   
        }
    }

    private IEnumerator MoveTowardsTarget() {
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        if(Vector3.Distance(endPosition, this.transform.position) <  0.5){
            
            yield return new WaitForSeconds(pause);
            transform.position = startPosition;
        }
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }
}
