using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public Sprite sprite;
    [TextArea]
    public string sentence;
}
