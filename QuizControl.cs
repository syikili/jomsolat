using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class QuizControl : MonoBehaviour {

    public Text questionText;
    public Text scoreDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public Text timeRemainingDisplayText;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();

        isRoundActive = true;
        
	}

    private void ShowQuestion()
    {
        RemoveAnswerButton();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            answerButtonGameObjects.Add(answerButtonGameObject);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointAddedForCorrectAnswers;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }

        else
        {
            EndRound();
        }
    }

    public void EndRound ()
    {
        isRoundActive = false;
        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }
    private void RemoveAnswerButton()
    {
       while (answerButtonGameObjects.Count >0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);

        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("LetsStartQuiz");
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    if(isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();
        }

        if (timeRemaining <= 0f)
        {
            EndRound();
        }
	}


}
