using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;

public class Main_menu : MonoBehaviour {

	public Button tutorial;
	public Button journey;
	public Button games;
	public Button achievement;
	public Button report;
	public Button multiplayer;
	//public Button logout;
    //public Text user;

    public Authenticate userSignedIn;

	// Use this for initialization
	public void Start () {
		tutorial = tutorial.GetComponent<Button> ();
		journey = journey.GetComponent<Button> ();
		games = games.GetComponent<Button> ();
		achievement = achievement.GetComponent<Button> ();
		report = report.GetComponent<Button> ();
		multiplayer = multiplayer.GetComponent<Button> ();
		//logout = logout.GetComponent<Button> ();
        //user = user.GetComponent<Text>();
		
	}

	public void Tutorial () {
		SceneManager.LoadScene ("Tutorial");
	}

	public void Journey () {
		SceneManager.LoadScene ("Journey");
	}

	public void Games () {
		SceneManager.LoadScene ("Games");
	}

	public void Achievement () {
		SceneManager.LoadScene ("Achievement");
	}

	public void Report () {
		SceneManager.LoadScene ("Report");
	}

	public void Multiplayer () {
		SceneManager.LoadScene ("Multiplayer");
	}

	public void Logout () {
		SceneManager.LoadScene ("main");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
