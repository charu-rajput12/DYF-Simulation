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
    public List<Dialogue> dialogue_AfterLibrary;

    public DialogManager dialogManager;
    public RandomWords randomWords;
    public int wordCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        //if (Globals.visitedQuest.Contains())
        //{
        //    Globals.currentQuest = 1;
        //    // dialogManager.StartDialogue(dialogue);
        //    dialogManager.pauseDialogues += ShowWords;
        //}
            dialogManager.pauseDialogues += ShowWords;

    }
    public void StartQuest()
    {
        QuestLogManager.instance.SetStatus(0, 0);

        Debug.Log("here...");
        if(!Globals.afterLibrary)
            dialogManager.StartDialogue(dialogue);
        else
            dialogManager.StartDialogue(dialogue_AfterLibrary);

    }


    private void ShowWords(int obj)
    {   
        if(obj == 1)
        {
            wordScreen.SetActive(true);
            inputField.text = "";
            word.text = randomWords.GenerateRandomWord();
            wordCount++;
        }
        else
        {
            PlayerManager.CanPlayerMove = true;
            UIGameplay.ShowUI();
            if (Globals.afterLibrary)
            {
                QuestManager.EndQuest(0);

            }
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
}
