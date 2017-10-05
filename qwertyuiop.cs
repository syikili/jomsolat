using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Auth;
using Firebase;



public class qwertyuiop : MonoBehaviour {

    public Button reset;
    public Text errorText;
   
    private string email = "syikili95@gmail.com";
    protected string displayName = "";
    private string logText = "";

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
   
    private bool fetchingToken = false;
    const int kMaxLogSize = 16382;

    private Vector2 controlsScrollViewVector = Vector2.zero;
    private Vector2 scrollViewVector = Vector2.zero;

    // Options used to setup secondary authentication object.
    private Firebase.AppOptions otherAuthOptions = new Firebase.AppOptions
    {
        ApiKey = "",
        AppId = "",
        ProjectId = ""
    };

   

        /// <summary>
        /// ///////////////////////////
        /// </summary>

    // Send a password reset email to the current email address.
    public void SendPasswordResetEmail()
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;

        string emailAddress = email;
        if (user != null)
        {
            auth.SendPasswordResetEmailAsync(emailAddress).ContinueWith(task =>
            {
                if (task.IsCanceled)
                {
                    errorText.text = "SendPasswordResetEmailAsync was canceled.";
                    //Debug.LogError("SendPasswordResetEmailAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    errorText.text = "SendPasswordResetEmailAsync encountered an error: ";
                    //Debug.LogError("SendPasswordResetEmailAsync encountered an error: " + task.Exception);
                    return;
                }

                errorText.text = "Password reset email sent successfully.";
                //Debug.Log("Password reset email sent successfully.");
            });
        }
    }

    // Handle initialization of the necessary firebase modules:
    void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    void Start()
    {
        reset.onClick.AddListener(() => SendPasswordResetEmail());
        InitializeFirebase();
    }

    
}
