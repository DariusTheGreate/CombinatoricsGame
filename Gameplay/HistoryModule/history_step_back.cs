using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemoryHistory;


public class history_step_back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void step_back()
    {
        if(history_container.history_of_destoyed.Count <= 0)
            return;

        foreach(Transform tr in GameObject.Find("Canvas").transform){
            if(tr.gameObject.tag == "k!" || tr.gameObject.tag == "num_n" || tr.gameObject.tag == "F" || tr.gameObject.tag == "num_k")
            {
                Destroy(tr.gameObject);
                //print(tr.gameObject.name);
            }
        }

        IEnumerable toopen = history_container.history_of_destoyed.Pop().memory_;
        foreach(GameObject obj in toopen)
        {
            obj.transform.SetParent(GameObject.Find("Canvas").transform);
            obj.transform.SetSiblingIndex(998);
            obj.GetComponent<item_drop>().enabled = true;
            obj.GetComponent<drop_item>().enabled = true;
            obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
        if(history_container.to_destoy.Count <= 0)
            return;
        var destr = history_container.to_destoy.Pop();
            
        Destroy(destr);//obj.transform.SetSiblingIndex(100);
        if(history_container.past_game_objects.Count <= 0)
            return;
        GameObject past_obj = history_container.past_game_objects.Pop();
        past_obj.transform.SetParent(GameObject.Find("Canvas").transform);
        past_obj.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        
    }
}
