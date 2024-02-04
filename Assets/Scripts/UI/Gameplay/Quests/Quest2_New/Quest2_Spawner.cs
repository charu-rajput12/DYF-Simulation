using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest2_Spawner : MonoBehaviour
{
    public List<GameObject> corridors;
    public List<GameObject> corridorsColliders;
    public List<GameObject> triggerColliders;
    public GameObject chestboxOpen, chestBoxClose;

    public List<Transform> spawnPoints;
    public Transform player;
    public DialogManager_Quest2 dialogManager;


    private void Start()
    {
        ToggleCorridors(0);
        dialogManager.removeCollider += RemoveTriggerCollider;
    }

    private void RemoveTriggerCollider()
    {
        foreach (var item in triggerColliders)
        {
            item.SetActive(false);
        }
    }

    public void ToggleCorridors(int index)
    {
        SpawnPlayerOnPoints(index);
        foreach (var item in triggerColliders)
        {
            item.SetActive(false);
        }
        foreach (var item in corridors)
        {
            item.SetActive(false);
        }
        foreach (var item in corridorsColliders)
        {
            item.SetActive(false);
        }
        corridors[index].SetActive(true);
        corridorsColliders[index].SetActive(true);
        triggerColliders[index].SetActive(true);
    }
    void SpawnPlayerOnPoints(int index)
    {
        player.position = spawnPoints[index].position;
    }

    public void OpenChestBox()
    {
        chestboxOpen.SetActive(true);
        chestBoxClose.SetActive(false);
        Invoke(nameof(BackToMainGame), 3f);
    }

    void BackToMainGame()
    {
        Globals.afterSphinxScroll = true;
        Globals.afterLibrary = false;
        SceneManager.LoadScene("GamePlay");
    }
}
