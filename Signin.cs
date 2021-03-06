﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase.Unity;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System;

public class Signin : MonoBehaviour {

	public Text email, password;
	public Button loginbtn, signuphere;
	private FirebaseAuth auth;
	public Text errorText;

	public void ClickSignUp(){
		SceneManager.LoadScene ("signup");
	}

	// Use this for initialization
	void Start () {

		auth = FirebaseAuth.DefaultInstance;

		email = email.GetComponent<Text> ();
		password = password.GetComponent<Text> ();
		errorText = errorText.GetComponent<Text> ();
		signuphere = signuphere.GetComponent<Button> ();

		loginbtn.onClick.AddListener (() => SignIn (email.text, password.text));
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void SignIn (string email, string password) {


		auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
			{


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

				FirebaseUser user = task.Result;
				Debug.LogFormat("User signed in successfully: {0} ({1})",
					user.DisplayName, user.UserId);

				PlayerPrefs.SetString("LoginUser", user != null ? user.Email : "Unknown");
				SceneManager.LoadScene("Main_menu");


			});

	}

}
