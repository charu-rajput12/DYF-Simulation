using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager_Quest2GamePlay : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] DialogManager dialogManager;

    public static DialogueManager_Quest2GamePlay instance;

    public List<Dialogue> dialogue_BeforeSphinx;
    public List<Dialogue> dialogue_AfterSphinx;

    private void Start()
    {
        instance = this;
    }
    public void StartQuest()
    {
        Debug.Log("start quest 2");
        if (!Globals.afterSphinxScroll)
        {
            QuestLogManager.instance.SetStatus(0, 1);
            StartQuest(0);
        }
        else
        {

            StartQuest(1);

        }

    }
    public void StartQuest(int index)
    {
        Debug.Log("index "+index);
        if (index == 0) dialogManager.StartDialogue(dialogue_BeforeSphinx);
        else dialogManager.StartDialogue(dialogue_AfterSphinx);
    }
}
