using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using Firebase.Auth;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuizQuestion : MonoBehaviour {

    private DatabaseReference _databaseReference;
    private string answerPath = "/Student_Users/1/Stud_Answer/Topic/Solat/";
    public InputField answer_text;
    public int totalscore, highscore;
    public bool isCorrect;
    public Button submitBtn;

    public void Start()
    {
        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        submitBtn.onClick.AddListener(onSubmit);
    }

    /*-------------------------------------------------------------------------------------------------------------*/
    //Writing student answers into Firebase Database    
    public class Student_Answer
    {
        public int question_no;
        public string stud_answer;
        public bool isCorrect;

        public Student_Answer(){}

        public Student_Answer(int question_no, string stud_answer, bool isCorrect)
        {
            this.question_no = question_no;
            this.stud_answer = stud_answer;
            this.isCorrect = isCorrect;
        }

    }

    //write exercise table into Firebase
    public class ChildExercise
    {
        public int totalscore;
        public int highscore;
        

        public ChildExercise() { }

        public ChildExercise( int totalscore, int highscore)
        {
            this.totalscore = totalscore;
            this.highscore = highscore;
            
        }

    }

    void Write_ChildExercise(string question_id, int totalscore, int highscore)
    {
        var childexercise = new ChildExercise(totalscore, highscore);
        string json = JsonUtility.ToJson(childexercise);


        //write to json format
        _databaseReference
            //.Child("Student_Users")
            //.Child(userID.ToString())
            .Child(answerPath)
            .Child(question_id)
            .SetRawJsonValueAsync(json);

        Debug.Log("Successfull!");
    }

    void Write_Student_Answer(string question_id, string question, int question_no, string stud_answer, bool isCorrect)
    {
        var childexercise = new Student_Answer(question_no, stud_answer, isCorrect);
        string json = JsonUtility.ToJson(childexercise);


        //write to json format
        _databaseReference
            //.Child("Student_Users")
            //.Child(userID.ToString())
            .Child(answerPath)
            .Child(question_id)
            .Child(question)
            .SetRawJsonValueAsync(json);

        Debug.Log("Successfull!");
    }

    public void onSubmit()
    {
        Write_ChildExercise("se1", 100, 80);
        Write_Student_Answer("se1", "q1", 1, "saya tak tahu", false);

    }




}
