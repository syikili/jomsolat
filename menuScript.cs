using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button login;
	public Button register;



	// Use this for initialization
	void Start () {

		//canvas
		quitMenu = quitMenu.GetComponent<Canvas> ();


		//buttons
		login = login.GetComponent<Button> ();
		register = register.GetComponent<Button> ();


		quitMenu.enabled = false; 

			
	}
	
	// Update is called once per frame
	public void ExitPress () {

		quitMenu.enabled = true;
		login.enabled = false;
		register.enabled = false;

	}

	public void NoPress() {

		quitMenu.enabled = false;
		login.enabled = true;
		register.enabled = true;
}

	public void Login(){
		SceneManager.LoadScene ("signin");
	}

	public void Signup(){
		SceneManager.LoadScene ("signup");
	}

	public void ExitGame(){
		Application.Quit ();
}
}