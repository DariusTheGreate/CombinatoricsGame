using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson_movement : MonoBehaviour
{
    private RectTransform start_trans;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public GameObject banner_button;
    public bool start_work;
    public GameObject target;
    public GameObject lesson_banner_0;
    public GameObject lesson_banner_1;
    public GameObject lesson_banner_2;
    public int speed= 100;
    public float pause = 0.2f;
    private int clickCount = 0;
    
    void Start()
    {
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }

    void Update()
    {
        if(GameObject.Find("BannerMessage").transform.GetSiblingIndex() < 10){
            if(lesson_banner_0 != null){
                //blureBack("quest");
                lesson_banner_0.transform.SetSiblingIndex(1000);
            }
            start_work = true;
        }
        else
            start_work = false;

        if (start_work && Input.GetMouseButtonDown(0) && Vector3.Distance(Input.mousePosition, banner_button.transform.position) > 100){
	        if(clickCount == 0)
                Destroy(lesson_banner_0);
            if(clickCount == 1){
                Destroy(lesson_banner_1);
                gameObject.GetComponent<CanvasGroup>().alpha = 0f;
                gameObject.transform.SetSiblingIndex(0);
            }
            if(clickCount == 2)
                Destroy(lesson_banner_2);
            
            clickCount++;
            if(clickCount == 1){

                //blureBack("F");
                //blureBack("n!");
                lesson_banner_1.transform.SetSiblingIndex(1000);
            }
            if(clickCount == 2){
                //blureBack("answer_spot");
                lesson_banner_2.transform.SetSiblingIndex(1000);
            }
            
            //Destroy(lesson_banner_2);
            //Destroy(gameObject);
        }

        if(start_work && clickCount == 1)
            StartCoroutine(MoveTowardsTarget());   
    }

    private IEnumerator MoveTowardsTarget() {
        float step = speed * Time.deltaTime; 
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);
        if(Vector3.Distance(endPosition, this.transform.position) <  0.5){
            
            yield return new WaitForSeconds(pause);
            transform.position = startPosition;
        }
        
    }

    void blureBack(string t)
    {
        foreach(Transform obj in GameObject.Find("Canvas").transform)
        {
            if(obj.GetComponent<CanvasGroup>() != null){
                obj.GetComponent<CanvasGroup>().alpha = 0.4f;
                print(obj.name);
            }
            if(obj.tag == t)
                obj.GetComponent<CanvasGroup>().alpha = 1f;
                
        }
        foreach(Transform obj in GameObject.Find("Adaptability object").transform)
        {
            if(obj.GetComponent<CanvasGroup>() != null && obj.tag != t){
                obj.GetComponent<CanvasGroup>().alpha = 0.4f;
                print(obj.name);
            }
            if(obj.tag == t)
                obj.GetComponent<CanvasGroup>().alpha = 1f;
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }
}
