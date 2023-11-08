using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public event Action<int> invokeNextStep;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter : " + collision.collider.name);
        if(collision.collider.name == "Library Door")
        {
            GameManager.LoadScene(EScene.Library_Maze);
        }
        else if (collision.collider.name == "librarian")
        {
            invokeNextStep.Invoke(0);
        }
        else if (collision.collider.name == "librarian 2")
        {
            invokeNextStep.Invoke(1);

        }
        else if (collision.collider.name == "hint shelf")
        {
            invokeNextStep.Invoke(2);
        }
        else if (collision.collider.name == "ancient scroll box")
        {
            invokeNextStep.Invoke(3);
        }
    }
}
