using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using Firebase.Auth;
using System.Linq;
using UnityEngine.SceneManagement;


public class FirebaseScript : MonoBehaviour
{

    // REALTIME DATABASE
    private DatabaseReference _databaseReference;
    public InputField fullname, username, email, password, gender, category, age, parentEmel;
    public Button submit, studentButton,parentButton, login, okay, maybeLater;
    public Text message,identity;
    private Text student, parent;
    public Canvas popup, parentPanel;
    private string fn, us, em, pw, gd, ctgry, pe;
    private string ag;
    private string module;
    private string msg;
    public string user;
    public bool pelajar;        //isStudent true or false

    //AUTHENTICATON
    //public Text emailText, passwordText;    
    private FirebaseAuth auth;
    public Text errorText;


    void Start()
    {

        popup.enabled = false;
        parentPanel.enabled = false;

        errorText = errorText.GetComponent<Text>();

        // Set this before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://jom-solat-app.firebaseio.com/");

        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        Button submitBtn = submit.GetComponent<Button>();
        Button okayBtn = okay.GetComponent<Button>();

        //submitBtn.onClick.AddListener(() => WriteNewUser(003, fn, us, em, pw, gd, ctgry, ag));
        submitBtn.onClick.AddListener(onClickSubmit);

        //Authentication
        auth = FirebaseAuth.DefaultInstance;
        submitBtn.onClick.AddListener(() => SignUp(email.text, password.text));
        okayBtn.onClick.AddListener(() => SignUp(email.text, password.text));

        //write new user manually
        // WriteNewUser(001, "Nurasyikin binti Zulkafli", "syikili", "syikin@gmail.com", "123", "female", "beginner", 22);
        //WriteNewUser(002, "Syafiq bin Zulkafli", "chup", "syafiq@gmail.com", "12345", "male", "beginner", 27);
        //WriteNewUser(003, fn, us, em, pw, gd, ctgry, ag);

        //read user maunally
        //ReadUser(001, "Nurasyikin binti Zulkafli", "syikili", "syikin@gmail.com", "123", "female", "beginner", 22);


    }

    public void Notify_Parent_Okay_Clicked()
    {
        //parentPanel.enabled = true;
        fn = fullname.GetComponent<InputField>().text;
        us = username.text;
        em = email.text;
        pw = password.text;
        gd = gender.text;
        user = identity.text;
        pe = parentEmel.text;
        //ctgry = category.text;
        ag = age.text;

        Debug.Log(pe);

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
        SignUp(email.text, password.text);
        parentPanel.enabled = false;
        popup.enabled = true;
        message.text = " Registration Complete";


        //pe = parentEmel.text;

    }

    public void Notify_Parent_MaybeLater_Clicked()
    {        
        parentPanel.enabled = false;
        fn = fullname.GetComponent<InputField>().text;
        us = username.text;
        em = email.text;
        pw = password.text;
        gd = gender.text;
        user = identity.text;
        //pe = parentEmel.text;
        //ctgry = category.text;
        ag = age.text;

        /// Debug.Log(pe);

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
        SignUp(email.text, password.text);
        popup.enabled = true;
        message.text = " Registration Complete";
        parentPanel.enabled = false;
    }

    public void IsStudent()
    {
           
            parentPanel.enabled = true;
       
    }
    public void Student_OnClick()
    {
        //Button studentbtn = student.GetComponent<Button>();
        user = "student";
        pelajar = true;
        Debug.Log(user);
        identity.text = "STUDENT";
    }

    public void Parent_OnClick()
    {
        //Button parentbtn = parent.GetComponent<Button>();
        user = "parent";
        pelajar = false;
        Debug.Log(user);
        identity.text = "PARENT";
    }   

    public void onClickSubmit()
    {

            SignUp(email.text, password.text);

        /*if (pelajar == true)
        {
            IsStudent();
        }*/

            if (user == "student")
            {
                parentPanel.enabled = true;
            }

            if (user == "parent")
        {

                fn = fullname.GetComponent<InputField>().text;
                us = username.text;
                em = email.text;
                pw = password.text;
                gd = gender.text;
                user = identity.text;
                //pe = parentEmel.text;
                //ctgry = category.text;
                ag = age.text;

                /// Debug.Log(pe);

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
            
            popup.enabled = true;
            message.text = " Registration Complete";
            parentPanel.enabled = false;

            //WriteNewUser(001, fn, us, em, pw, gd, module, ag);
        }    

    }

    public void Student_NotifyParent_Panel()
    {

    }

    public void loginPage()
    {
        SceneManager.LoadScene("signin");

    }

    public void readUser()
    {
        SceneManager.LoadScene("signin");
    }

    public class User
    {

        public string studentAge;
        public string fullName, username, email, password, gender, category;

        public User()
        {

        }

        public User( string fullName, string username, string email, string password, string gender, string category, string studentAge)
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
        var user = new User(fullName, username, email, password,  gender, category, studentAge);
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


    //AUTHENTICATION
    public void SignUp(string email, string password)
    {

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            //Error handling
            return;
        }

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled)
        {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            return;
        }
        if (task.IsFaulted)
        {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
            if (task.Exception.InnerExceptions.Count > 0)
                UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
            return;
        }

        FirebaseUser newUser = task.Result; // Firebase user has been created.
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            newUser.DisplayName, newUser.UserId);
        UpdateErrorMessage("Signup Success");


        //SceneManager.LoadScene("signin");
        }
        );
    }

    private void UpdateErrorMessage(string message)
    {
        errorText.text = message;
        Invoke("ClearErrorMessage", 3);
    }

    void ClearErrorMessage()
    {
        errorText.text = "";
    }
    //Reading from Firebase Database
    /*void ReadUser(int userID, string fullName, string username, string email, string password, string gender, string category, string studentAge)
    {
        FirebaseDatabase.DefaultInstance.GetReference("Student_Users").Child("2").GetValueAsync().ContinueWith(task =>
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
                string json5 = snapshot.Child("studentAge").GetRawJsonValue();
                Debug.Log("User Info \nFullname: " + json1 +  "\nEmail: " + json2 + "\nGender: " + json3 + "\nCategory: " + json4 + "\nStudentAge: " + json5);
            }
        }
            );

        /*FirebaseDatabase.DefaultInstance.GetReference("Student_Users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Failure");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                string json = snapshot.Child("fullName").GetRawJsonValue();
                Debug.Log("User Info || Fullname: " + json);
            }
        }
            );*/



    //}


}

    /**********************************************************************************************************************************/

    /*public class QuestData
    {
        public int questId;
        public bool isCompleted;

        public QuestData()
        {
        }

        public QuestData(int questId, bool isCompleted)
        {
            this.questId = questId;
            this.isCompleted = isCompleted;
        }
    }*/

    //writing
    /*void WriteNewQuestData(int userId, int questId, bool isCompleted)
    {
        var questData = new QuestData(questId, isCompleted);
        string json = JsonUtility.ToJson(questData);

        // Write to the database in Json format
        _databaseReference
            .Child("users")
            .Child(userId.ToString())
            .SetRawJsonValueAsync(json);


        // When writing the value directly
        //      _databaseReference
        //          .Child ("users")
        //          .Child (userId.ToString ())
        //          .Child (questId.ToString ())
        //          .SetValueAsync (isCompleted);
    }*/

    // Read
    /* void ReadQuestData(int userId)
     {
         FirebaseDatabase.DefaultInstance
             .GetReference("users")
             .GetValueAsync().ContinueWith(task => {
                 if (task.IsFaulted)
                 {
                     Debug.LogError("failure");
                 }
                 else if (task.IsCompleted)
                 {
                     DataSnapshot snapshot = task.Result;
                     string json = snapshot.Child(userId.ToString())
                         .GetRawJsonValue();
                     Debug.Log("Read: " + json);
                 }
             });
     }*/


