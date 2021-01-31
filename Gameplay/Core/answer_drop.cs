using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Linq;

public class answer_drop : MonoBehaviour
{
	public string answer_tag;
	public GameObject buttonToNextLevel;
	public GameObject Canvas;
    public GameObject answer_content;
    public AudioSource WinAudio;
	private GameObject res_n;
	private GameObject res_k;
	public int optional_k = -1;
	public int optional_n = -1;
	public int perfect_move_counter = -1;
	public int price = 15;
	void Start()
	{
        this.gameObject.tag = "answer_spot";
		Canvas = GameObject.Find("Canvas");
		buttonToNextLevel.SetActive(false);
	}

   	public void OnDropF(GameObject eventData)
    {
        if(eventData != null){
        	if(eventData.tag == answer_tag && optional_n == -1 && optional_k == -1){
                print("optional k and n is -1");
        		PositiveResult();
        		Destroy(eventData);
        		InstantiateButtonToNextLevel();
        		
        	}
        	else if(eventData.tag == answer_tag && optional_n != -1 && optional_k != -1)
        	{
                print("optional k and n tot -1");
        		GetChildN(eventData);
        		GetChildK(eventData);
        		int num_n, num_k;
        		if(Int32.TryParse(res_n.transform.GetComponent<Text>().text, out num_n) && num_n == optional_n && Int32.TryParse(res_k.transform.GetComponent<Text>().text, out num_k) && num_k == optional_k){//Int32.Parse(eventData.transform.GetChild(1).GetComponent<Text>().text) == optional_k && Int32.Parse(eventData.transform.GetChild(2).GetComponent<Text>().text) == optional_n){
        			PositiveResult();
        			Destroy(res_n);
        			Destroy(res_k);
        			Destroy(eventData);
        			InstantiateButtonToNextLevel();
        		}
        		else
        			NegativeResult();
        	}
        	else if(eventData.tag == answer_tag && optional_n != -1)
        	{
                print("optional n tot -1");
        		GetChildN(eventData);
        		GetChildK(eventData);
        		int num_n;
        		if(Int32.TryParse(res_n.transform.GetComponent<Text>().text, out num_n) && num_n == optional_n){// && Int32.TryParse(res_k.transform.GetComponent<Text>().text, out num_k) && num_k == optional_k){//Int32.Parse(eventData.transform.GetChild(1).GetComponent<Text>().text) == optional_k && Int32.Parse(eventData.transform.GetChild(2).GetComponent<Text>().text) == optional_n){
        			PositiveResult();
        			Destroy(res_n);
        			Destroy(res_k);
        			Destroy(eventData);
        			InstantiateButtonToNextLevel();
        		}
        		else
        			NegativeResult();
        	}
        	else if(eventData.tag == answer_tag && optional_k != -1)
        	{
                print("optional k tot -1");
        		GetChildN(eventData);
        		GetChildK(eventData);
        		int num_k;
        		if(Int32.TryParse(res_k.transform.GetComponent<Text>().text, out num_k) && num_k == optional_k){// && Int32.TryParse(res_k.transform.GetComponent<Text>().text, out num_k) && num_k == optional_k){//Int32.Parse(eventData.transform.GetChild(1).GetComponent<Text>().text) == optional_k && Int32.Parse(eventData.transform.GetChild(2).GetComponent<Text>().text) == optional_n){
        			PositiveResult();
        			Destroy(res_n);
        			Destroy(res_k);
        			Destroy(eventData);
        			InstantiateButtonToNextLevel();
        		}
        		else
        			NegativeResult();
        	}

        	else{
        		NegativeResult();
        	}

        }
    }

    void GetChildN(GameObject obj)
    {
    	foreach (Transform eachChild in obj.transform) {
     		if (eachChild.name == "n" || eachChild.name == "n(Clone)") {
     			res_n = eachChild.gameObject;
                //print(res_n);
     		}
 		}
 		//if(res_n != null) 
	  	//	print(res_n.transform.GetComponent<Text>().text);
    }

    void GetChildK(GameObject obj)
    {
    	foreach (Transform eachChild in obj.transform) {
     		if (eachChild.name == "k" || eachChild.name == "k(Clone)") {
     			res_k = eachChild.gameObject;
                print(res_k);
     		}
 		}
 		//if(res_k != null)
	 	//	print(res_k.transform.GetComponent<Text>().text);
    }

    void PositiveResult()
    {
        if(!shareMoneyAmount.passed_scenes.Contains(SceneManager.GetActiveScene().name)  && !RandomTransitionContainer.randomTransition){
            //print(SceneManager.GetActiveScene().name);
            shareMoneyAmount.number += price;
            shareMoneyAmount.passed_scenes.Add(SceneManager.GetActiveScene().name);
        }
        WinAudio.Play();
        answer_content.transform.SetSiblingIndex(999);
        gameObject.transform.GetChild(0).GetComponent<Text>().text = "Верна";
    }
    void NegativeResult()
    {
    	gameObject.transform.GetChild(0).GetComponent<Text>().text = "Не верно";
    }

    void InstantiateButtonToNextLevel()
    {
        victory_container.is_victory = true;
    	buttonToNextLevel.SetActive(true);
    }
}
