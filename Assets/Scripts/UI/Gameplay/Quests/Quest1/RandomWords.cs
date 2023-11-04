using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWords : MonoBehaviour
{
    public List<string> words;
    public List<int> prevIndex;

    public string GenerateRandomWord()
    {
        int index = Random.Range(0, words.Count);
        if (!prevIndex.Contains(index))
            prevIndex.Add(index);
        else
            GenerateRandomWord();
        return words[index];
    }

}
