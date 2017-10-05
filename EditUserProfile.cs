using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Linq;
using UnityEngine.SceneManagement;

public class EditUserProfile : MonoBehaviour {


    private DatabaseReference _databaseReference;
    public InputField fullname, username, email;
    public Dropdown gender1, category1;
    private string gndr, ctgr;
    public Button submit;
    //private string fn, us, em, pw, gd, ctgry;
  //  private string ag;
  //  private string module;
  //  private string msg;
    //public InputField fullname, username, email, password, gender, category, age;

    enum Gender
    {
        Male,
        Female
    }

    enum Category
    {
        Beginner,
        Intermediate
    }

    public void GenderDropdown_IndexChanged(int index)
    {

        Gender jantina = (Gender)index;
        gndr = jantina.ToString();
        Debug.Log(jantina.ToString());
       
       
    }

    public void CategoryDropdown_IndexChanged(int index)
    {
        Category kategori = (Category)index;
        ctgr = kategori.ToString();
        Debug.Log(ctgr);
    }

    void PopulateList()
    {
        string[] enumGender  = Enum.GetNames(typeof(Gender));
        List<string> gender = new List<string>(enumGender);
        gender1.AddOptions(gender);

        string[] enumCategory = Enum.GetNames(typeof(Category));
        List<string> category = new List<string>(enumCategory);
        category1.AddOptions(category);
    }
    // Use this for initialization
    void Start () {

        PopulateList();

        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;


        //READ USER DETAILS
        ReadUser(001);

        Button submitBtn = submit.GetComponent<Button>();
        //submitBtn.onClick.AddListener(() => WriteNewUser(003, fn, us, em, pw, gd, ctgry, ag));
        //submitBtn.onClick.AddListener(onClickSubmit);

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
                gndr = json3.Trim("\"".ToCharArray());
                ctgr = json4.Trim("\"".ToCharArray());
                email.text = json2.Trim("\"".ToCharArray());

                Debug.Log("User Info \nFullname: " + json1 + "\nEmail: " + json2 + "\nGender: " + json3 + "\nCategory: " + json4 + "\nStudentAge: " + json5);
            }
        }
            );
    }

    public class User
    {

        public string studentAge;
        public string fullName, username, email, password, gender, category;

        public User()
        {

        }

        public User(string fullName, string username, string email, string password, string gender, string category, string studentAge)
        {
            this.fullName = fullName;
            this.username = username;
            this.email = email;
            this.password = password;
            this.gender = gender;
            this.category = category;
            this.studentAge = studentAge;
        }
    }

    //Writing into Firebase Database
    void WriteNewUser(int userID, string fullName, string username, string email, string password, string gender, string category, string studentAge)
    {
        var user = new User(fullName, username, email, password, gender, category, studentAge);
        string json = JsonUtility.ToJson(user);


        //write to json format
        _databaseReference
            .Child("Student_Users")
            .Child(userID.ToString())
            .SetRawJsonValueAsync(json);

        Debug.Log("Registration Successful");


        // When writing the value directly
        //      _databaseReference
        //          .Child ("users")
        //          .Child (userId.ToString ())
        //          .Child (questId.ToString ())
        //          .SetValueAsync (isCompleted);
    }

    /*public void onClickSubmit()
    {


        fn = fullname.GetComponent<InputField>().text;
        us = username.text;
        em = email.text;
        //pw = password.text;
       // gd = gender.text;
        //ctgry = category.text;
      //  ag = age.text;

        if (ag == "7")
        {
            module = "module1";
        }
        else if (ag == "8")
        {
            module = "module1";

        }

        else if (ag == "9")
        {
            module = "module1";

        }

        else if (ag == "10")
        {
            module = "module2";

        }
        else if (ag == "11")
        {
            module = "module2";

        }
        else if (ag == "12")
        {
            module = "module2";

        }

        WriteNewUser(001, fn, us, em, pw, gd, module, ag);

        
    
    }*/

    // Update is called once per frame
    void Update () {
		
	}
}
