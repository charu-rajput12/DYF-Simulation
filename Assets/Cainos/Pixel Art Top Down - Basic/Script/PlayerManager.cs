using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision enter : " + collision.collider.name);
        if(collision.collider.name == "Library Door")
        {
            GameManager.LoadScene(EScene.Library_Maze);
        }
    }
}
