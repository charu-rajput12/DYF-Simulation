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

    private void Awake()
    {
        Globals.inMainGamePlay = false;
    }
    void Start()
    {
        playerManager.invokeNextStep += ShowDialogue;
    }

    private void ShowDialogue(int obj)
    {
        tempDialogueList.Clear();

        switch (obj)
        {
            case 0:
                tempDialogueList = librarianDialogue;
                break;

            case 1:
                tempDialogueList = librarian2Dialogue;
                break;

            case 2:
                ShowHintPopUp();
                return;

            case 3:
                ShowAncientScroll();
                return;

            //case 4:
            //    LoadNextScene();
            //    return;
        }

        StartDialogue(tempDialogueList);
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
        LoadNextScene();
    }
    void LoadNextScene()
    {
        //FadeInOut.instance.FadeInNOut();
        GameManager.LoadScene(EScene.Gameplay);
        Globals.afterLibrary = true;
    }
}
