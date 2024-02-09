using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using UnityEngine.UI;

public class DialogManager_Quest2 : MonoBehaviour
{
    [SerializeField] GameObject dialogueScreen;
    [SerializeField] TMP_Text speakerName;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] Image speakerImage;
    [SerializeField] GameObject rightDialgueScreenContinue;
    [SerializeField] GameObject wrongDialgueScreenContinue;
    [SerializeField] Quest2_SphinxRiddle quest2_SphinxRiddle;

    public List<Dialogue> dialogue_InShinx;
    public List<Dialogue> dialogue_InShinxWrongRiddleAns;

    public event Action removeCollider;

    public void PlayDialogue(int index)
    {
        dialogueScreen.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Quest2_Sphinx")
        {
            speakerName.text = dialogue_InShinx[index].name;
            dialogueText.text = dialogue_InShinx[index].sentence;
            speakerImage.sprite = dialogue_InShinx[index].sprite;
        }
        rightDialgueScreenContinue.SetActive(true);
        wrongDialgueScreenContinue.SetActive(false);

    }
    public void PlayWrongAnsRiddleDialogue(int index)
    {
        dialogueScreen.SetActive(true);
        if (SceneManager.GetActiveScene().name == "Quest2_Sphinx")
        {
            speakerName.text = dialogue_InShinxWrongRiddleAns[index].name;
            dialogueText.text = dialogue_InShinxWrongRiddleAns[index].sentence;
        }
        rightDialgueScreenContinue.SetActive(false);
        wrongDialgueScreenContinue.SetActive(true);
    }

    public void Continue()
    {
        dialogueScreen.SetActive(false);
        removeCollider?.Invoke();
        PlayerManager.CanPlayerMove = true;
    }
    public void BackToRiddle()
    {
        dialogueScreen.SetActive(false);
        quest2_SphinxRiddle.StartRiddle();
    }
   

}
