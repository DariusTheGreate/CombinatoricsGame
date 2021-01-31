using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_menu : MonoBehaviour
{
    public GameObject menu;
    Vector2 deltav = new Vector2(1000, 0);
    Vector2 standart_menu_position = new Vector2(0,0);
    Vector2 stop_menu_position;
    public int screen_count = 1;

    void Start()
    {
        menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(PlayerPrefs.GetFloat("menu_position_screen_x"), 0f);
        stop_menu_position = deltav*screen_count;
    }

    void Update()
    {
        PlayerPrefs.SetFloat("menu_position_screen_x", (menu.GetComponent<RectTransform>().anchoredPosition).x);
    }

    public void menu_translate_left()
    {
        if(menu.GetComponent<RectTransform>().anchoredPosition != standart_menu_position)
    	   menu.GetComponent<RectTransform>().anchoredPosition += deltav;
    }

    public void menu_translate_right()
    {
        if(menu.GetComponent<RectTransform>().anchoredPosition != -stop_menu_position)
            menu.GetComponent<RectTransform>().anchoredPosition -= deltav;
    }
}
