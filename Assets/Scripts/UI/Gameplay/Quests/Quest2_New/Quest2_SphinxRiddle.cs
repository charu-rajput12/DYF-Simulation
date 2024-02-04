using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quest2_SphinxRiddle : MonoBehaviour
{
    public List<Riddle> riddles;
    public GameObject riddleScreen;
    public TMP_Text heading;
    public TMP_Text riddleQuestion;
    public List<TMP_Text> riddleOptions;
    public GameObject dialogueScreen;

    public DialogManager_Quest2 dialogManager_Quest2;
    string rightAns;
    string SelectedAns;

    public void StartRiddle()
    {
        PlayRiddle();
    }
    public int counter = 0;
    void PlayRiddle()
    {
        riddleScreen.SetActive(true);
        dialogueScreen.SetActive(false);

        heading.text = riddles[counter].Heading;

        riddleQuestion.text = riddles[counter].sentence;

        for (int i = 0; i < riddleOptions.Count; i++)
        {
            riddleOptions[i].text = riddles[counter].options[i];
        }
        rightAns = riddles[counter].correctAns;
    }
    public void OnSelectedAnswer(TMP_Text tMP_Text)
    {
        SelectedAns = tMP_Text.text;
    }
    public void CheckAnswer()
    {
        if(SelectedAns == rightAns)
        {
            Debug.Log("right answer "+ SelectedAns);
            dialogManager_Quest2.PlayDialogue(counter);
            counter++;
        }
        else
        {
            Debug.Log("wrong answer " + SelectedAns);
            dialogManager_Quest2.PlayWrongAnsRiddleDialogue(counter);
        }
        riddleScreen.SetActive(false);
    }

}
[System.Serializable]
public class Riddle
{
    public string Heading;
    [TextArea]
    public string sentence;
    public string[] options;
    public string correctAns;
}