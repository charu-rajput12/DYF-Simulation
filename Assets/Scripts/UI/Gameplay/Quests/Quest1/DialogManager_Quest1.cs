using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager_Quest1 : MonoBehaviour
{
    public GameObject wordScreen;
    public TMP_Text word;
    public TMP_InputField inputField;
    public List<Dialogue> dialogue;
    public DialogManager dialogManager;
    public RandomWords randomWords;
    public int wordCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Globals.currentQuest = 1;
        dialogManager.StartDialogue(dialogue);
        dialogManager.stopDialogues += ShowWords;
    }

    private void ShowWords(int obj)
    {   
        if(obj == 1)
        {
            wordScreen.SetActive(true);
            word.text = randomWords.GenerateRandomWord();
            wordCount++;
        }
        else
        {
            Gameplay.CanPlayerMove = true;
        }

    }
    public void NextWord()
    {
        if(wordCount >= 5)
        {
            wordScreen.SetActive(false);

            dialogManager.ReturnToDialogue();
        }
        else
        {
            ShowWords(1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger enter : "+collision.name);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter : " + collision.collider.name);
    }
}
