/*
* able to calculate score points
*read question and answers
*determine if the question is right or wrong
*
*PROBLEMS
*unable to stop after the last question
*unable to save student answers, points to firebase
*the question indicator not functional
*hints not available yet
*no timer
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;
using System.Reflection;

public class QuizQuestionBehaviour : MonoBehaviour {

    
    public Text questionText, userpoints , topicTitle, exerciseTtile, questionStatus, buttonText, answerStatus;    
    public Image correctIcon, wrongIcon;
    public Button answerBtn;
    public InputField answerInput;
    private bool newQuestion;
    public Sprite OffSprite, OnSprite;
    private DatabaseReference _databaseReference;
    public string path = "Questions/Topic/Solat/se2";
    private string answerPath = "/Student_Users/1/Stud_Answer/Topic/Solat/se1/q1/";
    private string answer,q;
    private bool statusJawapan, buttonClicked;
    private int i = 1;
    private string questionPoints;   
    private int parseQuestionPoints;
    private string parseCorrectAnswer;
    private int studPoints = 0;
    private string questionNumber = "q" +1;


    /*-------------------------------------------------------------------------------------------------------------*/
    //calculate accumulated points
    public int calculatePoints()
    {
        parseQuestionPoints = Int32.Parse(questionPoints);

        if (statusJawapan == true)
                {
                    studPoints += parseQuestionPoints;
                    Debug.Log(studPoints);
                }

                else
                {
                    studPoints += 0;
                    Debug.Log(studPoints);

                }

        return studPoints;
    }

    //isCorrect or not
    public bool isCorrect()
    {
        if (answerInput.text == parseCorrectAnswer)
        {
            statusJawapan = true;
            calculatePoints();
            Answer_CorrectOutput();
           
        }

        else
        {
            statusJawapan = false;
            calculatePoints();
            Answer_WrongOutput();
        }
        return statusJawapan;
    }

    /*-------------------------------------------------------------------------------------------------------------*/
    //behaviour of interface
    public void ChangeImageButton()
    {
        if (answerBtn.image.sprite == OnSprite)
        {
            answerBtn.image.sprite = OffSprite;
            buttonText.text = "Submit";
            newQuestion = true;
            Debug.Log(newQuestion);
        }

        else 
        {
            answerBtn.image.sprite = OnSprite;
            buttonText.text = "Next";
            newQuestion = false;
            Debug.Log(newQuestion);           
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
        statusJawapan = true;
    }

    public void Answer_WrongOutput()
    {
        answerStatus.text = "Wrong !";  //answer status
        answerStatus.color = Color.red; //answer status color
        wrongIcon.enabled = true;       //show wrong icon
        Text text = answerInput.transform.FindChild("Text").GetComponent<Text>(); //change text in input field to red when wrong
        text.color = Color.red;
        statusJawapan = false;


    }

    public void Button_OnClick()
    {
       // buttonClicked = true;        
        isCorrect();        
        ChangeImageButton();
        Next_Question();        
    }

    //display question
    public string Next_Question()
    {
        if (newQuestion == true )
        {
            //for(int i=0; i<11; i++)
            {
                i++;
                questionNumber = "q"+ i;
                Debug.Log(questionNumber);
                buttonClicked = false;
                newQuestion = false;
                Hide();
                answerStatus.text = "";
                answerInput.text = "";
                Text text = answerInput.transform.FindChild("Text").GetComponent<Text>(); //reset color font to black
                text.color = Color.black;
            }
            
        }

        return questionNumber;
    }

	// Use this for initialization
	void Start () {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        //question display
        newQuestion = false;
        //ReadQuestion(questionNumber);

        //hide element
        Hide();

        Debug.Log(newQuestion);

        //answer button action
        Button button = answerBtn.GetComponent<Button>();
        button.onClick.AddListener(Button_OnClick);
	}
	
	// Update is called once per frame
	void Update ()
    {
        ReadQuestion(questionNumber);
    }

    /*-------------------------------------------------------------------------------------------------------------*/

    //Reading questions from Firebase Database
    string ReadQuestion(string qid) // I CHANGE TO STRING FROM INT
    {
        FirebaseDatabase.DefaultInstance.GetReference(path).Child(questionNumber).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failure");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string json1 = snapshot.Child("question_no").GetRawJsonValue();
                string json2 = snapshot.Child("question_text").GetRawJsonValue().Trim("\"".ToCharArray());
                string json3 = snapshot.Child("question_point").GetRawJsonValue();
                string json4 = snapshot.Child("correct_answer").GetRawJsonValue();

                //questionPoints = Int32.Parse(json3); //COMMENTED THIS
                questionPoints = json3; 


                // var index = json1.Length;

                questionText.text = json1 + ". " +json2.Trim("\"".ToCharArray());
                userpoints.text = studPoints + " points";
                

                Debug.Log("Question " + json1 + ": " + json2);

                parseCorrectAnswer = json4.Trim("\"".ToCharArray());

                Debug.Log("Answer " + parseCorrectAnswer);
            }
        }
            );
        return questionPoints;
#pragma warning disable CS0162 // Unreachable code detected
        return parseCorrectAnswer;
#pragma warning restore CS0162 // Unreachable code detected

    }

   /* string ReadQuestion1(string qid)
    {
        FirebaseDatabase.DefaultInstance.GetReference(path).Child(questionNumber).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failure");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string json5 = snapshot.Child("correct_answer").GetRawJsonValue();

                parseCorrectAnswer = json5.Trim("\"".ToCharArray());
                
                Debug.Log("Answer " + parseCorrectAnswer);
            }
        }
            );
        return parseCorrectAnswer;
    }*/

    

    /*-------------------------------------------------------------------------------------------------------------*/

    //Writing student answers into Firebase Database
    //STILL CANNOT !!

    /*public class NewAnswer{

        private string stud_answer, question;
        private bool isCorrect;

        public NewAnswer()
        {
        }

        public NewAnswer( string stud_answer, bool isCorrect)
        {
            this.stud_answer = stud_answer;
            this.isCorrect = isCorrect;
            //this.question = question;
        }
      

    }

    void Write_StudentAnswer( string question, string stud_answer, bool isCorrect) {

        var studAns = new NewAnswer( stud_answer, isCorrect);
        string json = JsonUtility.ToJson(studAns);

        //write to json format
        _databaseReference
            
            .Child(answerPath)
            .Child(question)
            .SetRawJsonValueAsync(json);

       
        Debug.Log("Answer Saved !");


        // When writing the value directly
        //      _databaseReference
        //          .Child ("users")
        //          .Child (userId.ToString ())
        //          .Child (questId.ToString ())
        //          .SetValueAsync (isCompleted);
    }
    */
}
