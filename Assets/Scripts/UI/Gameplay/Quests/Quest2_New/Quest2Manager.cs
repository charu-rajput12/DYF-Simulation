using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest2Manager : MonoBehaviour
{
    public PlayerManager playerManager;
    [SerializeField] GameObject sphinxScroll;
    [SerializeField] GameObject chestboxOpen, chestBoxClose;

    private void Awake()
    {
        Globals.inMainGamePlay = false;
    }
    private void Start()
    {
        playerManager.invokeNextStep += TriggerChestBox;
    }

    private void TriggerChestBox(int obj)
    {
        if (obj == 0)
            OpenChestBox();
    }

    public void OpenChestBox()
    {
        Debug.Log("scroll box ..");
        QuestLogManager.instance.SetStatus(2, 1);
        chestboxOpen.SetActive(true);
        chestBoxClose.SetActive(false);
        ShowAncientScroll(true);
        Invoke(nameof(BackToMainGame), 3f);
    }

    void BackToMainGame()
    {
        Globals.afterSphinxScroll = true;
        Globals.afterLibrary = false;
        ShowAncientScroll(false);
    }
    void ShowAncientScroll(bool flag)
    {
        sphinxScroll.SetActive(flag);
        if (!flag)
        {
            //FadeInOut.instance.FadeInNOut();
            GameManager.LoadScene(EScene.Gameplay);
        }
    }

}
