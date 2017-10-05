using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Linq;
using UnityEngine.SceneManagement;

public class UserProfile : MonoBehaviour {

    private DatabaseReference _databaseReference;
    public Text fullname, username, email, gender, category;

    // Use this for initialization
    void Start () {

        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        //READ USER DETAILS
        ReadUser(001);
    }

    //Reading from Firebase Database
    void ReadUser(int userID)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Student_Users").Child("1").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failure");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string json1 = snapshot.Child("fullName").GetRawJsonValue();
                string json2 = snapshot.Child("email").GetRawJsonValue();
                string json3 = snapshot.Child("gender").GetRawJsonValue();
                string json4 = snapshot.Child("category").GetRawJsonValue();
                string json5 = snapshot.Child("username").GetRawJsonValue();


               // var index = json1.Length;

                fullname.text = json1.Trim("\"".ToCharArray());
                username.text = json5.Trim("\"".ToCharArray());
                gender.text = json3.Trim("\"".ToCharArray());
                category.text = json4.Trim("\"".ToCharArray());
                email.text = json2.Trim("\"".ToCharArray());

                Debug.Log("User Info \nFullname: " + json1 + "\nEmail: " + json2 + "\nGender: " + json3 + "\nCategory: " + json4 + "\nStudentAge: " + json5);
            }
        }
            );

        /*FirebaseDatabase.DefaultInstance
             .GetReference("Student_Users")
             .GetValueAsync().ContinueWith(task => {
                 if (task.IsFaulted)
                 {
                     Debug.LogError("failure");
                 }
                 else if (task.IsCompleted)
                 {
                     DataSnapshot snapshot = task.Result;
                     string json = snapshot.Child(userID.ToString())
                         .GetRawJsonValue();
                     Debug.Log("Read: " + json);
                 }
             });*/
    }


        // Update is called once per frame
        void Update () {
		
	}
}
