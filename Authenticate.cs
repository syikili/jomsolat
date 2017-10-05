using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;

public class Authenticate : MonoBehaviour {

	//Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	public Text email, password;
	public Button signupbtn, loginbtn, signinhere, signuphere;
	private FirebaseAuth auth;
	public Text errorText;
	public Text player;


	public void ClickSignIn(){
		SceneManager.LoadScene ("signin");
	}

	public void ClickSignUp(){
		SceneManager.LoadScene ("signup");
	}

	// Use this for initialization
	void Start () {

		auth = FirebaseAuth.DefaultInstance;

		email = email.GetComponent<Text> ();
		password = password.GetComponent<Text> ();
		errorText = errorText.GetComponent<Text> ();
		signinhere = signinhere.GetComponent<Button> ();
		signuphere = signuphere.GetComponent<Button> ();

		signupbtn.onClick.AddListener (() => Signup (email.text, password.text));
		loginbtn.onClick.AddListener (() => Signin (email.text, password.text));



	}

	public void Signup (string email, string password){

		if (string.IsNullOrEmpty (email) || string.IsNullOrEmpty (password)) {
			//Error handling
			return;
		}

		auth.CreateUserWithEmailAndPasswordAsync (email, password).ContinueWith (task => {
			if (task.IsCanceled) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError ("CreateUserWithEmailAndPasswordAsync error: " + task.Exception);
				if (task.Exception.InnerExceptions.Count > 0)
					UpdateErrorMessage (task.Exception.InnerExceptions [0].Message);
				return;
			}

			FirebaseUser newUser = task.Result; // Firebase user has been created.
			Debug.LogFormat ("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			UpdateErrorMessage ("Signup Success");


			SceneManager.LoadScene("signin");




			/*newUser.SendEmailVerificationAsync ().ContinueWith (t => {
				if (UpdateTaskStatusMessage (task, "SendEmailVerificationAsync")) {
					UpdateErrorMessage ("SendEmailVerificationAsync Success");
				}
			});*/


		}
		);}





	/*auth.SignInWithCustomTokenAsync(username, password).ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("SignInWithCustomTokenAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("SignInWithCustomTokenAsync encountered an error: " + task.Exception);
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1}))",
				newUser.DisplayName, newUser.UserId);


		});	

		Firebase.Auth.FirebaseUser user = auth.CurrentUser;
		if (user != null) {
			string name = user.DisplayName;
			string email = user.Email;
			System.Uri photo_url = user.PhotoUrl;
			// The user's Id, unique to the Firebase project.
			// Do NOT use this value to authenticate with your backend server, if you
			// have one; use User.TokenAsync() instead.
			string uid = user.UserId;
		}

		SceneManager.LoadScene("LoginStatus");
		*/



	private void UpdateErrorMessage(string message)
	{
		errorText.text = message;
		Invoke("ClearErrorMessage", 3);
	}

	void ClearErrorMessage()
	{
		errorText.text = "";
	}

	public void Signin (string email, string password) {


		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
			{

				FirebaseUser user = task.Result;
				if (task.IsCanceled)
				{
					Debug.LogError("SignInWithEmailAndPasswordAsync canceled.");
					return;
				}
				if (task.IsFaulted)
				{
					Debug.LogError("SignInWithEmailAndPasswordAsync error: " + task.Exception);
					if (task.Exception.InnerExceptions.Count > 0)
						UpdateErrorMessage(task.Exception.InnerExceptions[0].Message);
					return;
				}

				/*if (UpdateTaskStatusMessage (task, "SignInWithEmailAndPasswordAsync"))
						{				

							//FirebaseUser user = task.Result;

							if (!user.IsEmailVerified)
							{
								UpdateErrorMessage("The email is not verified yet");
								auth.SignOut();
								return;
							}
						}*/

				//FirebaseUser user = task.Result;
				Debug.LogFormat("User signed in successfully: {0} ({1})",
					user.DisplayName, user.UserId);

				PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
				SceneManager.LoadScene("Main_menu");


			});

	}



}

