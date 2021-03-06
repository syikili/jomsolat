﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;

public class Signup : MonoBehaviour {

	public Text email, password;
	public Button signupbtn, signinhere;
	private FirebaseAuth auth;
	public Text errorText;


	public void ClickSignIn(){
		SceneManager.LoadScene ("signin");
	}

	// Use this for initialization
	void Start () {

		auth = FirebaseAuth.DefaultInstance;

		email = email.GetComponent<Text> ();
		password = password.GetComponent<Text> ();
		errorText = errorText.GetComponent<Text> ();

		signupbtn.onClick.AddListener (() => SignUp (email.text, password.text));
		
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


	public void SignUp (string email, string password){

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
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
