using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TMP_Text subjectName;
    public TMP_Text dialogText;
    public Image subjectPic;
    int dialogueIndex;
    private List<Dialogue> tempDialogueList = new List<Dialogue>();
    public void StartDialogue(List<Dialogue> dialogues)
    {
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
        dialogueIndex++;
        if(dialogueIndex < tempDialogueList.Count)
            PlayDialogue(tempDialogueList[dialogueIndex]);
    }
}
