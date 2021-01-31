using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemoryHistory;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class item_drop : MonoBehaviour //IDropHandler
{
	private GameObject dropped;
	private Vector3 start_dropped;
	public Text DistanceText;
    private Vector3 box_pos;
	public int priceForFormUp = 25;
	private GameObject Akn_badge;
    private CanvasGroup canvasGroup;
    
    private Sprite red_texture;
    private Sprite green_texture;
    private Sprite blue_texture;
    private Sprite yellow_texture;
	
    private GameObject Ckn_badge;
	private GameObject Pn_badge;
	private GameObject Canvas;

	void Start()
	{
        red_texture = Resources.Load<Sprite>("red_texture");
        green_texture = Resources.Load<Sprite>("green_texture");
        blue_texture = Resources.Load<Sprite>("blue_texture");
        yellow_texture = Resources.Load<Sprite>("yellow_texture");
        box_pos = new Vector3(-10,-10,0);
        canvasGroup  = GetComponent<CanvasGroup>();
		Canvas = GameObject.Find("Canvas");
		Akn_badge = GameObject.Find("Ank_reserve");
		Ckn_badge = GameObject.Find("Cnk_reserve");
		Pn_badge = GameObject.Find("Pn_reserve");
	}

    public void OnDropF(GameObject eventData)
    {
        if(eventData != null){

            if(false && eventData.tag == "num_n" && gameObject.tag == "n!")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                gameObject.transform.Find("number!").GetComponent<Text>().text = (text_of_draged.text + "!".ToString());
                if(eventData != null)
                    Destroy(eventData);
                gameObject.tag = "num_n";
            }

            if(eventData.tag == "num_n" && gameObject.tag == "Akn")
            {   
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                gameObject.transform.Find("n").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(eventData);
            }

            if(eventData.tag == "num_k" && gameObject.tag == "Akn")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;  
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                gameObject.transform.Find("k").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(eventData);
            }
            
            if(eventData.tag == "num_n" && gameObject.tag == "Ckn")
            {
        
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                gameObject.transform.Find("n").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(eventData);

            }

            if(eventData.tag == "num_k" && gameObject.tag == "Ckn")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                gameObject.transform.Find("k").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(eventData);
            }


            if(eventData.tag == "minus_n" && gameObject.tag == "num_n" || eventData.tag == "minus_n" && gameObject.tag == "num_k")
            {
                
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current - value__text_of_draged;
                if(res_value < 0)
                    return;
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                gameObject.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(eventData != null)
                    Destroy(eventData);
            }

            if(eventData.tag == "num_n" && gameObject.tag == "minus_n" || eventData.tag == "num_k" && gameObject.tag == "minus_n")
            {
                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = eventData.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current - value__text_of_draged;
            
                if(res_value < 0)
                    return;
                
                eventData.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
                eventData.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(gameObject != null)
                    Destroy(gameObject);
            }

            if(eventData.tag == "num_plus_n" && gameObject.tag == "num_n" || eventData.tag == "num_plus_n" && gameObject.tag == "num_k")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current + value__text_of_draged;
                gameObject.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(eventData != null)
                    Destroy(eventData);
            }

            if(gameObject.tag == "num_plus_n" && eventData.tag == "num_n" || gameObject.tag == "num_plus_n" && eventData.tag == "num_k")
            {
                gameObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = eventData.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current + value__text_of_draged;
                eventData.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(gameObject != null)
                    Destroy(gameObject);
            }

            if(eventData.tag == "dividion_n" && gameObject.tag == "num_n" || eventData.tag == "dividion_n" && gameObject.tag == "num_k")
            {
                
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                double res_value = value__text_of_current / value__text_of_draged;
                
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                gameObject.transform.Find("number").GetComponent<Text>().text = (Math.Round(res_value)).ToString();
                
                if(eventData != null)
                    Destroy(eventData);
            }

            if(gameObject.tag == "dividion_n" && eventData.tag == "num_n" || gameObject.tag == "dividion_n" && eventData.tag == "num_k")
            {
                
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                double res_value = value__text_of_draged / value__text_of_current;
                gameObject.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                eventData.transform.Find("number").GetComponent<Text>().text = (Math.Round(res_value)).ToString();
                
                if(gameObject != null)
                    Destroy(gameObject);
            }

            if(eventData.tag == "multiply_n" && gameObject.tag == "num_n" || eventData.tag == "multiply_n" && gameObject.tag == "num_k")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current * value__text_of_draged;
                gameObject.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(eventData != null)
                    Destroy(eventData);     //eventData.transform.SetSiblingIndex(0);

            }

            if(gameObject.tag == "multiply_n" && eventData.tag == "num_n" || gameObject.tag == "multiply_n" && eventData.tag == "num_k")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (eventData.transform.Find("number").GetComponent<Text>());
                int value__text_of_draged = Int32.Parse(text_of_draged.text);
                Text text_of_current = gameObject.transform.Find("number").GetComponent<Text>();
                int value__text_of_current = Int32.Parse(text_of_current.text);
                int res_value = value__text_of_current * value__text_of_draged;
                eventData.transform.Find("number").GetComponent<Text>().text = (res_value).ToString();
                
                if(gameObject != null)
                    Destroy(gameObject);     //eventData.transform.SetSiblingIndex(0);

            }

            if(/*eventData.tag == "(k-n)!" && gameObject.tag == "n!" || eventData.tag == "n!" && gameObject.tag == "(k-n)!" ||*/ eventData.tag == "(k-n)!" && gameObject.tag == "Pn" || eventData.tag == "Pn" && gameObject.tag == "(k-n)!")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                var components =  Akn_badge.GetComponents<Text>();
                foreach(Transform i in transform)
                {
                    GameObject.Destroy(i.gameObject);
                }
                var startAPosition = Akn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
                var startNPosition = Akn_badge.transform.GetChild(2).GetComponent<Text>().transform.localPosition;
                var startKPosition = Akn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;
                var start_n_value = Akn_badge.transform.GetChild(2).GetComponent<Text>().text;
                var p_n_value = "n";
                if(gameObject.tag == "Pn")
                    p_n_value = gameObject.transform.GetChild(1).GetComponent<Text>().text;
                else if(eventData.tag == "Pn")
                    p_n_value = eventData.transform.GetChild(1).GetComponent<Text>().text;
                
                var start_k_value = Akn_badge.transform.GetChild(1).GetComponent<Text>().text;
                Akn_badge.transform.GetChild(1).GetComponent<Text>().text = "k".ToString();
                Akn_badge.transform.GetChild(2).GetComponent<Text>().text = "n".ToString();
                var A = Instantiate(Akn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var k = Instantiate(Akn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var n = Instantiate(Akn_badge.transform.GetChild(2).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                A.transform.localPosition = startAPosition;
                k.transform.localPosition = startKPosition;
                n.transform.localPosition = startNPosition;

                A.name = "A";
                n.name = "n";
                k.name = "k";
                if(eventData != null)
                    Destroy(eventData);
                Akn_badge.transform.GetChild(1).GetComponent<Text>().text = start_k_value;
                Akn_badge.transform.GetChild(2).GetComponent<Text>().text = start_n_value;
                n.GetComponent<Text>().text = p_n_value;

                gameObject.tag = "Akn";
            }

            if(/*eventData.tag == "Akn" && gameObject.tag == "k!" ||*/ eventData.tag == "k!" && gameObject.tag == "Akn")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                var components =  Ckn_badge.GetComponents<Text>();

                foreach(Transform i in transform)
                {
                    GameObject.Destroy(i.gameObject);
                }

                var startCPosition = Ckn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
                var startKPosition = Ckn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;
                var startNPosition = Ckn_badge.transform.GetChild(2).GetComponent<Text>().transform.localPosition;
                
                var start_n_value = gameObject.transform.GetChild(2).GetComponent<Text>().text;

                var start_k_value = gameObject.transform.GetChild(1).GetComponent<Text>().text;

                var C = Instantiate(Ckn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var k = Instantiate(Ckn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var n = Instantiate(Ckn_badge.transform.GetChild(2).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                C.transform.localPosition = startCPosition;
                n.transform.localPosition = startNPosition;
                k.transform.localPosition = startKPosition;

                n.GetComponent<Text>().text = start_n_value;
                k.GetComponent<Text>().text = start_k_value; 
                C.name = "C";
                k.name = "k";
                n.name = "n";

                if(eventData != null)
                    Destroy(eventData);
                gameObject.tag = "Ckn";
            }

            if(/*eventData.tag == "Akn" && gameObject.tag == "k!" ||*/ eventData.tag == "Akn" && gameObject.tag == "k!")
            {
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                
                var components =  Ckn_badge.GetComponents<Text>();

                foreach(Transform i in transform)
                {
                    GameObject.Destroy(i.gameObject);
                }

                var startCPosition = Ckn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
                var startKPosition = Ckn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;
                var startNPosition = Ckn_badge.transform.GetChild(2).GetComponent<Text>().transform.localPosition;
                
                var start_k_value = eventData.transform.GetChild(1).GetComponent<Text>().text;
                var start_n_value = eventData.transform.GetChild(2).GetComponent<Text>().text;

                
                var C = Instantiate(Ckn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var k = Instantiate(Ckn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var n = Instantiate(Ckn_badge.transform.GetChild(2).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                C.transform.localPosition = startCPosition;
                n.transform.localPosition = startNPosition;
                k.transform.localPosition = startKPosition;

                n.GetComponent<Text>().text = start_n_value;
                k.GetComponent<Text>().text = start_k_value; 
                C.name = "C";
                k.name = "k";
                n.name = "n";

                if(eventData != null)
                    Destroy(eventData);
                gameObject.tag = "Ckn";
            }

            if(eventData.tag == "F" && gameObject.tag == "n!" || eventData.tag == "n!" && gameObject.tag == "F")
            {
                foreach(Transform i in transform)
                {
                    GameObject.Destroy(i.gameObject);
                }

                var startPPosition = Pn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
                var startNPosition = Pn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;

                var P = Instantiate(Pn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                var n = Instantiate(Pn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
                P.transform.localPosition = startPPosition;
                n.transform.localPosition = startNPosition;

                if(eventData != null){
                    Destroy(eventData);
                }
                gameObject.tag = "Pn";

                //history_container.to_destoy.Push(gameObject);
            }

            if(eventData.tag == "num_n" && gameObject.tag == "Pn")
            {
                //history_container.past_game_objects.Push(Instantiate(gameObject, gameObject.GetComponent<drop_item>().startPosition, Quaternion.identity));
                //history_container.to_destoy.Push(gameObject);
                var start_pn_value = Pn_badge.transform.GetChild(1).GetComponent<Text>().text;
                gameObject.transform.GetChild(1).GetComponent<Text>().text = eventData.transform.GetChild(0).GetComponent<Text>().text; 
                
                if(eventData != null)
                {
                    Destroy(eventData);
                }
                gameObject.tag = "Pn";
            }

            if(eventData.tag == "Ckn" && gameObject.tag == "num_n")
            {
        
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                eventData.transform.Find("n").GetComponent<Text>().text = text_of_draged.text;
                if(gameObject != null)
                    Destroy(gameObject);

            }

            if(eventData.tag == "Ckn" && gameObject.tag == "num_k")
            {
        
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                eventData.transform.Find("k").GetComponent<Text>().text = text_of_draged.text;
                if(gameObject != null)
                    Destroy(gameObject);

            }

            if(eventData.tag == "Akn" && gameObject.tag == "num_n")
            {   
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                eventData.transform.Find("n").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(gameObject);
            }

            if(eventData.tag == "Akn" && gameObject.tag == "num_k")
            {   
                eventData.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                Text text_of_draged = (gameObject.transform.Find("number").GetComponent<Text>());
                eventData.transform.Find("k").GetComponent<Text>().text = text_of_draged.text;
                if(eventData != null)
                    Destroy(gameObject);
            }

            if(eventData.tag == "Pn" && gameObject.tag == "num_n")
            {
                //history_container.past_game_objects.Push(Instantiate(gameObject, gameObject.GetComponent<drop_item>().startPosition, Quaternion.identity));
                //history_container.to_destoy.Push(gameObject);
                var start_pn_value = Pn_badge.transform.GetChild(1).GetComponent<Text>().text;
                eventData.transform.GetChild(1).GetComponent<Text>().text = gameObject.transform.GetChild(0).GetComponent<Text>().text; 
                
                if(eventData != null)
                {
                    Destroy(gameObject);
                }
                eventData.tag = "Pn";
            }
       }
        
        change_color_of_texture();
    }

    List<GameObject> GetAllBadgesOfScene()
    {
        List<GameObject> res = new List<GameObject>();
        foreach(Transform tr in Canvas.transform){
            if(tr.gameObject.tag == "k!" || tr.gameObject.tag == "num_n" || tr.gameObject.tag == "F" || tr.gameObject.tag == "num_k")
            {
                var pos = tr.gameObject.GetComponent<drop_item>().startPosition;
                var fr = Instantiate(tr.gameObject, pos, Quaternion.identity);
                fr.GetComponent<item_drop>().enabled = false;
                fr.GetComponent<drop_item>().enabled = false; 
                fr.transform.SetSiblingIndex(0);
                
                res.Add(fr);
            }
        }
        return res;
    }

    void change_color_of_texture()
    {
        if(gameObject.tag == "Akn" || gameObject.tag == "Ckn" || gameObject.tag == "Pn")
            gameObject.GetComponent<Image>().sprite = red_texture;
        if(gameObject.tag == "num_n" || gameObject.tag == "num_k")
            gameObject.GetComponent<Image>().sprite = green_texture;
        if(gameObject.tag == "n!" || gameObject.tag == "k!" || gameObject.tag == "(k-n)!")
            gameObject.GetComponent<Image>().sprite = blue_texture;
        if(gameObject.tag == "minus_n" || gameObject.tag == "dividion_n" || gameObject.tag == "multiply_n")
            gameObject.GetComponent<Image>().sprite = yellow_texture;
        
            
    }

    bool decrement_money_amount()
    {
    	if(shareMoneyAmount.number - priceForFormUp >= 0){
    		shareMoneyAmount.number -= priceForFormUp;
    		print("true");
    		return true;
    	}
    	return false;
    }

    public void form_up_logic()
    {
        if(gameObject.tag == "Pn")
        {
            if (!decrement_money_amount())
                return;

            var components =  Akn_badge.GetComponents<Text>();
            foreach(Transform i in transform)
            {
                GameObject.Destroy(i.gameObject);
            }

            var startAPosition = Akn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
            var startNPosition = Akn_badge.transform.GetChild(2).GetComponent<Text>().transform.localPosition;
            var startKPosition = Akn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;
            
            var start_n_value = Akn_badge.transform.GetChild(2).GetComponent<Text>().text;
            var start_k_value = Akn_badge.transform.GetChild(1).GetComponent<Text>().text;
            var start_obj_n_value = gameObject.transform.GetChild(1).GetComponent<Text>().text;
            
            Akn_badge.transform.GetChild(1).GetComponent<Text>().text = "k".ToString();
            Akn_badge.transform.GetChild(2).GetComponent<Text>().text = "n".ToString();
            
            var A = Instantiate(Akn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            var k = Instantiate(Akn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            var n = Instantiate(Akn_badge.transform.GetChild(2).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            
            A.transform.localPosition = startAPosition;
            k.transform.localPosition = startKPosition;
            n.transform.localPosition = startNPosition;
            
            A.name = "A";
            k.name = "k";
            n.name = "n";
            
            n.transform.GetComponent<Text>().text = start_obj_n_value;
            
            Akn_badge.transform.GetChild(1).GetComponent<Text>().text = start_k_value;
            Akn_badge.transform.GetChild(2).GetComponent<Text>().text = start_n_value;
            
            
            gameObject.tag = "Akn";
        }

        else if(gameObject.tag == "Akn")
        {
            if (!decrement_money_amount())
                return;

            var components =  Ckn_badge.GetComponents<Text>();

            foreach(Transform i in transform)
            {
                GameObject.Destroy(i.gameObject);
            }

            var startCPosition = Ckn_badge.transform.GetChild(0).GetComponent<Text>().transform.localPosition;
            var startKPosition = Ckn_badge.transform.GetChild(1).GetComponent<Text>().transform.localPosition;
            var startNPosition = Ckn_badge.transform.GetChild(2).GetComponent<Text>().transform.localPosition;
            
            var start_k_value = Ckn_badge.transform.GetChild(1).GetComponent<Text>().text;
            var start_n_value = Ckn_badge.transform.GetChild(2).GetComponent<Text>().text;
            var start_obj_k_value = gameObject.transform.GetChild(1).GetComponent<Text>().text;
            var start_obj_n_value = gameObject.transform.GetChild(2).GetComponent<Text>().text;

            var C = Instantiate(Ckn_badge.transform.GetChild(0).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            var k = Instantiate(Ckn_badge.transform.GetChild(1).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            var n = Instantiate(Ckn_badge.transform.GetChild(2).GetComponent<Text>(), gameObject.transform.position, gameObject.transform.rotation, gameObject.transform) as Text;
            
            C.transform.localPosition = startCPosition;
            n.transform.localPosition = startNPosition;
            k.transform.localPosition = startKPosition;

            n.GetComponent<Text>().text = start_n_value;
            k.GetComponent<Text>().text = start_k_value; 
            
            C.name = "C";
            n.name = "n";
            k.name = "k";
            
            n.transform.GetComponent<Text>().text = start_obj_n_value;
            k.transform.GetComponent<Text>().text = start_obj_k_value;

            Ckn_badge.transform.GetChild(1).GetComponent<Text>().text = start_k_value;
            Ckn_badge.transform.GetChild(2).GetComponent<Text>().text = start_n_value;
            gameObject.tag = "Ckn";
       }
    }
}
