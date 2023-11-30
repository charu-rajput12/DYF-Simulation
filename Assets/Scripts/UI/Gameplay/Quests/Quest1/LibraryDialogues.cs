using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LibraryDialogues : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject dialogueScreen;
    public TMP_Text subjectName;
    public TMP_Text dialogText;
    public Image subjectPic;
    public int dialogueIndex;
    public GameObject hintPopup;
    public GameObject ancientScroll, openBox, closeBox;
    private List<Dialogue> tempDialogueList = new List<Dialogue>();
    public List<Dialogue> librarianDialogue;
    public List<Dialogue> librarian2Dialogue;

    void Start()
    {
        playerManager.invokeNextStep += ShowDialogue;
    }

    private void ShowDialogue(int obj)
    {
        tempDialogueList.Clear();
        if(obj == 0)
        {
            tempDialogueList = librarianDialogue;
            StartDialogue(tempDialogueList);
        }
        else if (obj == 1)
        {
            tempDialogueList = librarian2Dialogue;
            StartDialogue(tempDialogueList);
        }
        else if (obj == 2)
            ShowHintPopUp();
        else if (obj == 3)
            ShowAncientScroll();
        else if (obj == 4)
            LoadNextScene();
    }

    public void StartDialogue(List<Dialogue> dialogues)
    {
        PlayerManager.CanPlayerMove = false;
        dialogueScreen.SetActive(true);
         dialogueIndex = 0;
        // start dialogue

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
        if(dialogueIndex == tempDialogueList.Count-1)
        {
            dialogueScreen.SetActive(false);
            PlayerManager.CanPlayerMove = true;
            return;
        }
        dialogueIndex++;
        if (dialogueIndex < tempDialogueList.Count)
            PlayDialogue(tempDialogueList[dialogueIndex]);
    }
    void ShowHintPopUp()
    {
        hintPopup.SetActive(true);
    }
    void ShowAncientScroll()
    {
        ancientScroll.SetActive(true);
        openBox.SetActive(true);
        closeBox.SetActive(false);
        QuestLogManager.instance.SetStatus(2, 0);

        Invoke("HideAncientScroll", 3);
    }
    void HideAncientScroll()
    {
        ancientScroll.SetActive(false);
        LibraryManager.instance.endCollider.SetActive(true);
    }
    void LoadNextScene()
    {
        GameManager.LoadScene(EScene.Gameplay);
        Globals.afterLibrary = true;
    }
}
