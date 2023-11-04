using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogueScreen;
    public TMP_Text subjectName;
    public TMP_Text dialogText;
    public Image subjectPic;
    public int dialogueIndex;
    private List<Dialogue> tempDialogueList = new List<Dialogue>();
    public event Action<int> stopDialogues;
    public void StartDialogue(List<Dialogue> dialogues)
    {
        Gameplay.CanPlayerMove = false;
        dialogueIndex = 0;
        // start dialogue
        tempDialogueList.Clear();
        tempDialogueList = dialogues;
        PlayDialogue(tempDialogueList[dialogueIndex]);

    }
    void PlayDialogue(Dialogue dialogue)
    {
        subjectName.text = dialogue.name;
        dialogText.text = dialogue.sentence;
        subjectPic.sprite = dialogue.sprite;
    }
    public void NextDialogue()
    {
        if (Globals.currentQuest == 1 )
        {
            if(dialogueIndex == 4)
            {
                dialogueScreen.SetActive(false);
                stopDialogues.Invoke(1);
                return;
            }
            else if(dialogueIndex == 7)
            {
                dialogueScreen.SetActive(false);
                stopDialogues.Invoke(2);
                return;
            }
        }

        dialogueIndex++;
        if(dialogueIndex < tempDialogueList.Count)
            PlayDialogue(tempDialogueList[dialogueIndex]);
    }
    public void ReturnToDialogue()
    {
        dialogueScreen.SetActive(true);
        dialogueIndex++;
        if (dialogueIndex < tempDialogueList.Count)
            PlayDialogue(tempDialogueList[dialogueIndex]);
    }
}
