using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest2_TriggerEvent : MonoBehaviour
{
    [SerializeField] Quest2_Spawner Quest2_Spawner;
    [SerializeField] Quest2_SphinxRiddle quest2_SphinxRiddle;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Quest2_Sphinx")
        {
            if(collision.collider.tag == "Player")
            {
                if (gameObject.name == "TriggerForRiddles")
                {
                    Debug.Log("trigger riddles ");
                    quest2_SphinxRiddle.StartRiddle();
                }
                else if (gameObject.name == "Door1")
                {
                    Debug.Log("trigger door 1");
                    Quest2_Spawner.ToggleCorridors(1);
                }
                else if (gameObject.name == "Door2")
                {
                    Debug.Log("trigger door 2");
                    Quest2_Spawner.ToggleCorridors(2);
                }
                else if (gameObject.name == "Door3")
                {
                    Debug.Log("trigger door 3");
                    Quest2_Spawner.ToggleCorridors(3);
                }
                else if (gameObject.name == "ChestBox")
                {
                    Debug.Log("trigger chest box");
                    Quest2_Spawner.OpenChestBox();
                }
            }
           
        }
    }
}
