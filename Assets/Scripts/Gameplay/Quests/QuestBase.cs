using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
}
public interface IQuest
{
    void StartQuest();
    void EndQuest();
}