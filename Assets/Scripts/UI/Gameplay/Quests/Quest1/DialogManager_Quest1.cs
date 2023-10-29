using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager_Quest1 : MonoBehaviour
{
    public List<Dialogue> dialogue;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
