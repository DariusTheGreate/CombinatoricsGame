using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesson_movement3 : MonoBehaviour
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

    void Start()
    {
        startPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        endPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }

    void Update()
    {
        if(GameObject.Find("BannerMessage").transform.GetSiblingIndex() < 10)
            start_work = true;
        else
            start_work = false;

        if (start_work && Input.GetMouseButtonDown(0) && Vector3.Distance(Input.mousePosition, banner_button.transform.position) > 100){
            Destroy(gameObject);
        }

        if(start_work)
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

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);
    }
}
