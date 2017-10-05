using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public Text answerText;
    public QuizControl quizController;
    private AnswerData answerData;

	// Use this for initialization
	void Start () {
        quizController = FindObjectOfType<QuizControl>();
	}

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText; 
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void HandleClick()
    {
        quizController.AnswerButtonClicked(answerData.isCorrect);
    }
}
