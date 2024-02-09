using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Codex_Gameplay : MonoBehaviour
{
    public GameObject Screen;
    public Color selectColor;
    public Color deSelectColor;

    public Image[] codexButton;
    public TMP_Text[] description;

    public static Codex_Gameplay instance;

    private void Start()
    {
        instance = this;
        ShowDescription(0);
    }
    public void ShowMainScreen()
    {
        Screen.SetActive(true);
    }
    public void ShowDescription(int index)
    {
        foreach (var item in codexButton)
        {
            item.color = deSelectColor;
        }

        codexButton[index].color = selectColor;
        foreach (var item in description)
        {
            item.gameObject.SetActive(false);
        }
        description[index].gameObject.SetActive(true);
        //if (index == 2)
        //{
        //    codexButton[3].gameObject.SetActive(true);
        //    codexButton[4].gameObject.SetActive(true);
        //}
        if(index == 0 || index == 1)
        {
            codexButton[3].gameObject.SetActive(false);
            codexButton[4].gameObject.SetActive(false);
        }
        else
        {
            codexButton[3].gameObject.SetActive(true);
            codexButton[4].gameObject.SetActive(true);
        }

    }
}
