using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Quest2GamePlay : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] DialogManager dialogManager;

    //[SerializeField] GameObject dialogueScreen;
    //[SerializeField] TMP_Text speakerName;
    //[SerializeField] TMP_Text dialogueText;
    //[SerializeField] Button continueBtn;


    public static DialogueManager_Quest2GamePlay instance;

    public List<Dialogue> dialogue_BeforeSphinx;
    public List<Dialogue> dialogue_AfterSphinx;

    //private List<Dialogue> tempDialogueList = new List<Dialogue>();
    //private int dialogueIndex;


    private void Start()
    {
        instance = this;
    }
    public void StartQuest(int index)
    {
        Debug.Log("index "+index);
        if (index == 0) dialogManager.StartDialogue(dialogue_BeforeSphinx);
        else dialogManager.StartDialogue(dialogue_AfterSphinx);
    }
    //void ShowDialogue(int index)
    //{
    //    //continueBtn.onClick.AddListener(Continue);
    //    tempDialogueList.Clear();
    //    // 0 for before sphinx , 1 for after sphinx
    //    if (index == 0) tempDialogueList = dialogue_BeforeSphinx;
    //    else tempDialogueList = dialogue_AfterSphinx;
    //}
    //public void PlayDialogue(int index)
    //{
    //    dialogueScreen.SetActive(true);
    //    speakerName.text = tempDialogueList[index].name;
    //    dialogueText.text = tempDialogueList[index].sentence;
    //}
    //public void Continue()
    //{

    //    if (dialogueIndex == tempDialogueList.Count - 1)
    //    {
    //        dialogueScreen.SetActive(false);
    //        PlayerManager.CanPlayerMove = true;
    //        return;
    //    }
    //    dialogueIndex++;
    //    if (dialogueIndex < tempDialogueList.Count)
    //        PlayDialogue(dialogueIndex);
    //}
}
