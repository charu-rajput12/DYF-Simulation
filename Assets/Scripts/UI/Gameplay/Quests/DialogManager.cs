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
    public List<Dialogue> tempDialogueList = new List<Dialogue>();
    public event Action<int> pauseDialogues;
    public void StartDialogue(List<Dialogue> dialogues)
    {
        Debug.Log("here 22");
        PlayerManager.CanPlayerMove = false;
        dialogueIndex = 0;
        // start dialogue
        tempDialogueList.Clear();
        tempDialogueList = dialogues;
        PlayDialogue(tempDialogueList[dialogueIndex]);

    }
    void PlayDialogue(Dialogue dialogue)
    {
        Debug.Log("here 33");

        subjectName.text = dialogue.name;
        dialogText.text = dialogue.sentence;
        subjectPic.sprite = dialogue.sprite;
        dialogueScreen.SetActive(true);
    }
    public void NextDialogue()
    {
        if (DataManager.GameData.PlayerData.currentQuest == 0)
        {
            if (dialogueIndex == 4 || dialogueIndex == tempDialogueList.Count - 1)
            {
                dialogueScreen.SetActive(false);
                pauseDialogues.Invoke(dialogueIndex == 4 ? 1 : 2);
                return;
            }
        }
        else if (DataManager.GameData.PlayerData.currentQuest == 1)
        {
            if (dialogueIndex == tempDialogueList.Count - 1)
            {
                dialogueScreen.SetActive(false);
                PlayerManager.CanPlayerMove = true;
                return;
            }
        }

        dialogueIndex++;
        if (dialogueIndex < tempDialogueList.Count)
        {
            PlayDialogue(tempDialogueList[dialogueIndex]);
        }
    }

    public void ReturnToDialogue()
    {
        dialogueScreen.SetActive(true);
        dialogueIndex++;
        if (dialogueIndex < tempDialogueList.Count)
            PlayDialogue(tempDialogueList[dialogueIndex]);
    }
}
