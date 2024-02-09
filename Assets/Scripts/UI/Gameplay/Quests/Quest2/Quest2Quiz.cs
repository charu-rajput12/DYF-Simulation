using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quest2Quiz : MonoBehaviour
{
	public GameObject[] QuizScreen;

	public List<Quest2QuizDetail> quest2QuizDetail;
	[Header("********Question Screen*******")]
	public TMP_Text ques;
	public TMP_Text[] answers;
	public Image[] OptionImage;
	public Color SelectedColor;
	public Color deSelectedColor;
	public Button checkButton;
	public int pathIndex;
	public int rightAnswer;
	public int selectedAnswer;
	public string resultString;

	[Header("*******Check Screen********")]
	public TMP_Text resultText;
	public TMP_Text CorrectAnswer;

	public static Quest2Quiz instance;

	int counter;

	void Start()
	{
		instance = this;
	}
	public void StartQuiz()
	{
		Debug.Log("show quest 2");
		counter = 0;
		ShowUI(0);
		ShowQuestions(0);
		checkButton.interactable = false;

	}
	public void ShowUI(int showScreenIndex)
	{
		foreach (var item in QuizScreen)
		{
			item.SetActive(false);
		}
		if (QuizScreen.Length != showScreenIndex)
			QuizScreen[showScreenIndex]?.SetActive(true);
	}
	public void EndQuiz()
	{
		ShowUI(2);
		PlayerManager.CanPlayerMove = true;
		//QuestLogManager.instance.SetStatus(3, 1);
	}

	//select path index
	public void SelectPathIndex(int index)
    {
		pathIndex = index;
    }
	public void SelectOption(int index)
	{
		checkButton.interactable = true;
		selectedAnswer = index;
		foreach (var item in OptionImage)
		{
			item.color = deSelectedColor;
		}
		OptionImage[index].color = SelectedColor;
	}
	public void ShowQuestions(int quesIndex)
	{
		List<string> tempAnswers = new List<string>();
		ques.text = quest2QuizDetail[pathIndex].questionData[quesIndex].quizQuestion;
		tempAnswers.AddRange(quest2QuizDetail[pathIndex].questionData[quesIndex].options);
		rightAnswer = quest2QuizDetail[pathIndex].questionData[quesIndex].correctAnsIndex;
		for (int i = 0; i < tempAnswers.Count; i++)
        {
			answers[i].text = tempAnswers[i];
			resultString = tempAnswers[rightAnswer];
		}
	}
	public void CheckAnswer()
    {
		if (rightAnswer == selectedAnswer)
        {
			resultText.text = "You Won !";
			if(counter == 0)
            {
				RewardsUI.instance.SaveAchivement(3); // achieved 1 index task in achievement
				RewardsUI.instance.ShowAchievmentPopup("Become a star");
			}
        }
		else
			resultText.text = "You Lose !";

		CorrectAnswer.text = resultString;
		ShowUI(1);
	}
	public void Done()
    {
		if(counter == 0)
        {
			counter++;
			ShowUI(0);
			ShowQuestions(1);  // show second question
			foreach (var item in OptionImage)
			{
				item.color = deSelectedColor;
			}
			//QuestLogManager.instance.SetStatus(1, 1);
			checkButton.interactable = false;

		}
		else
        {
			//QuestLogManager.instance.SetStatus(2, 1);
			EndQuiz();

		}
	}

}
[System.Serializable]
public class Quest2QuizDetail
{
	public string currentSelectedPath;
	public List<Quest2Data> questionData;
}
[System.Serializable]
public class Quest2Data{
	public string quizQuestion;
	public string[] options;
	public int correctAnsIndex;
}
