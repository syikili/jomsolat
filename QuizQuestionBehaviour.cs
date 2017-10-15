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
    private string answerPath = "/Student_Users/1/Stud_Answer/Topic/Solat/se1/q1/";
    private string answer,q;
    private bool statusJawapan, buttonClicked;
    private int i = 0;
    public string questionNumber = "q" +1;

    /*-------------------------------------------------------------------------------------------------------------*/
    //behaviour of interface
    public void ChangeImageButton()
    {
        if (answerBtn.image.sprite == OnSprite)
        {                   
            answerBtn.image.sprite = OffSprite;
            buttonText.text = "Submit";
            newQuestion = false;
            Debug.Log(newQuestion);
        }

        else 
        {
            answerBtn.image.sprite = OnSprite;
            buttonText.text = "Next";
            newQuestion = true;
            Debug.Log(newQuestion);
            //Next_Question();

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
        buttonClicked = true;
        Answer_WrongOutput();   
        //Changes the button's Normal color to the new color.
        //answerBtn.image.color = Color.blue;
        ChangeImageButton();
        Next_Question();
        //Debug.Log(newQuestion);

        //grab student answer and answer status
        /*answer = answerInput.text;
        q = "q1";
        Debug.Log(answer);
        statusJawapan = false;
        Debug.Log(statusJawapan);*/

        //Write_StudentAnswer(  "q1" , answerInput.text, statusJawapan);


    }

    public string Next_Question()
    {
       
        
        if (newQuestion == true && buttonClicked == true)
        {
            //for(int i=0; i<11; i++)
            {
                i++;
                questionNumber = "q"+ i;
                Debug.Log(questionNumber);
                buttonClicked = false;
                newQuestion = false;
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

        ReadQuestion(questionNumber);

        //hide element
        Hide();

        //answer button action
        Button button = answerBtn.GetComponent<Button>();
        button.onClick.AddListener(Button_OnClick);
	}
	
	// Update is called once per frame
	void Update () {
        //Next_Question();
        ReadQuestion(questionNumber);
	}

    /*-------------------------------------------------------------------------------------------------------------*/

    //Reading questions from Firebase Database
    void ReadQuestion(string qid)
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



                // var index = json1.Length;

                questionText.text = json2.Trim("\"".ToCharArray());
                userpoints.text = json3 + " points";
                

                Debug.Log("Question " + json1 + ": " + json2);
            }
        }
            );
    }

    /*-------------------------------------------------------------------------------------------------------------*/

    //Writing student answers into Firebase Database
    //STILL CANNOT !!

    public class NewAnswer{

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
}
