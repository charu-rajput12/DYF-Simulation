using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Quest1Quiz : MonoBehaviour
{
	public GameObject[] QuizScreen;
	public GameObject warningPopup;
	[Header("*******Quiz 1 Screen*********")]
	public Image[] quizTopicImage;
	public Color SelectedColor;
	public Color deSelectedColor;
	public Button nextButton_1;

	[Header("*******Quiz 2 Screen*********")]
	public TMP_Text[] allAnswerText;
	public Image[] quizAnswerImage;
	public Quest1QuizDetail[] quest1QuizDetail;
	public TMP_Text chooseTopic;
	public int selectedAnswer;
	public int correctAnswer;


	[Header("*******Quiz 3 Screen*********")]
	public TMP_Text resultText;
	public TMP_Text mainTopic;
	public TMP_Text[] mindMapCorrectText;

	public static Quest1Quiz instance;
	public int currentMindmapIndex;
    // Start is called before the first frame update
    void Start()
    {
		instance = this;
	}
	public void StartQuiz()
    {
		nextButton_1.interactable = false;      


		ShowUI(0);
	}
	public void ShowUI(int showScreenIndex)
	{
		foreach (var item in QuizScreen)
		{
			item.SetActive(false);
		}
		if(QuizScreen.Length != showScreenIndex)
			QuizScreen[showScreenIndex]?.SetActive(true);
	}

	public void EndQuiz()
    {
		ShowUI(3);
		PlayerManager.CanPlayerMove = true;
		//QuestLogManager.instance.SetStatus(3,0);
		RewardsUI.instance.SaveAchivement(1); // achieved 1 index task in achievement
		RewardsUI.instance.ShowAchievmentPopup("Complete any quiz");

	}

	public void SelectedMindmapTopic(int currentIndex)
    {
		nextButton_1.interactable = true;
		currentMindmapIndex = currentIndex;
		foreach (var item in quizTopicImage)
		{
			item.color = deSelectedColor;
		}
		quizTopicImage[currentIndex].color = SelectedColor;
		ShowTopicAllAnswer(currentIndex);
		chooseTopic.text = quest1QuizDetail[currentIndex].quizSelectedName;

	}
	public void ShowTopicAllAnswer(int index)
    {
		for(int i=0; i< allAnswerText.Length; i++)
        {
			allAnswerText[i].text = quest1QuizDetail[index].quizAnswer[i].ToString();
        }
	}
	public void SelectedMindmapAnswer(int answerIndex)
	{
		if(selectedAnswer < 4)
        {
			if(quizAnswerImage[answerIndex].color != SelectedColor)
            {
				quizAnswerImage[answerIndex].color = SelectedColor;
				selectedAnswer++;
				if (quest1QuizDetail[currentMindmapIndex].correct[answerIndex])
					correctAnswer++;
			}

		}
	}
	public void CheckAnswer()
    {
		if (selectedAnswer != 4)
        {
			warningPopup.SetActive(true);
			return;
        }
		//QuestLogManager.instance.SetStatus(2, 0);

		ShowUI(2);
		if (correctAnswer == 4)
			resultText.text = "You Won !";
		else
			resultText.text = "You Lose !";

		int tempIndex = 0;
		mainTopic.text = quest1QuizDetail[currentMindmapIndex].quizSelectedName;
		for (int i = 0; i < quest1QuizDetail[0].quizAnswer.Length; i++)
		{
            if (quest1QuizDetail[currentMindmapIndex].correct[i])
            {
				mindMapCorrectText[tempIndex].text = quest1QuizDetail[currentMindmapIndex].quizAnswer[i].ToString();
				tempIndex++;
            }
		}
	}

}
[System.Serializable]
public class Quest1QuizDetail
{
	public string quizSelectedName;
	public string[] quizAnswer;
	public bool[] correct;
}
