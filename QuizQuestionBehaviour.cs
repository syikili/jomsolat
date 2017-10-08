using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class QuizQuestionBehaviour : MonoBehaviour {

    public Text questionText, userpoints , topicTitle, exerciseTtile, questionStatus, buttonText, answerStatus;    
    public Image correctIcon, wrongIcon;
    public Button answerBtn;
    public InputField answerInput;
    private bool newQuestion;
    public Sprite OffSprite, OnSprite;
    private DatabaseReference _databaseReference;
    private string path = "Questions/Topic/Solat/se2";


    public void ChangeImageButton()
    {
        if (answerBtn.image.sprite == OnSprite)
        {                   
            answerBtn.image.sprite = OffSprite;
            buttonText.text = "Submit";
            newQuestion = false;
        }

        else
        {
            answerBtn.image.sprite = OnSprite;
            buttonText.text = "Next";
            newQuestion = true;
        }
    }

    //hides correct and wrong icon
    public void Hide()
    {
        correctIcon.enabled = false;
        wrongIcon.enabled = false;

    }

    public void Answer_CorrectOutput()
    {
        answerStatus.text = "Correct !";
        answerStatus.color = Color.green;
        correctIcon.enabled= true;
    }

    public void Answer_WrongOutput()
    {
        answerStatus.text = "Wrong !";  //answer status
        answerStatus.color = Color.red; //answer status color
        wrongIcon.enabled = true;       //show wrong icon
        Text text = answerInput.transform.FindChild("Text").GetComponent<Text>(); //change text in input field to red when wrong
        text.color = Color.red;

    }

    public void Button_OnClick()
    {
        Answer_WrongOutput();
        //Changes the button's Normal color to the new color.
        //answerBtn.image.color = Color.blue;
        ChangeImageButton();
        Debug.Log(newQuestion);


    }

	// Use this for initialization
	void Start () {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        ReadQuestion("q1");

        //hide element
        Hide();

        //answer button action
        Button button = answerBtn.GetComponent<Button>();
        button.onClick.AddListener(Button_OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Reading from Firebase Database
    void ReadQuestion(string qid)
    {
        FirebaseDatabase.DefaultInstance.GetReference(path).Child("q1").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failure");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string json1 = snapshot.Child("question_no").GetRawJsonValue();
                string json2 = snapshot.Child("question_text").GetRawJsonValue();
                string json3 = snapshot.Child("question_point").GetRawJsonValue();
                string json4 = snapshot.Child("correct_answer").GetRawJsonValue();
                string json5 = snapshot.Child("username").GetRawJsonValue();


                // var index = json1.Length;

                questionText.text = json2.Trim("\"".ToCharArray());
                userpoints.text = json3.Trim("\"".ToCharArray());
                

                Debug.Log("Question " + json1 + ": " + json2);
            }
        }
            );
    }
}
