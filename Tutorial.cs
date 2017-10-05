using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tutorial : MonoBehaviour {

	public Button tutorial1;
	//public Button finish;
	//public Button home;
	//public Button games;
   // public Button autoPlay;
    public GameObject buttonPrefab;
    public Transform buttonContainer;


    // Use this for initialization
    void Start () {
		tutorial1 = tutorial1.GetComponent<Button> ();
	//	finish = finish.GetComponent<Button> ();
      //  home = home.GetComponent<Button>();
     //   autoPlay = autoPlay.GetComponent<Button>();

        var tutorialList = new string[] { "wudhu", "solat subuh", "solat zohor", "solat asar", "solat maghrib" };
        foreach (var t in tutorialList)
        {
            GameObject tutorial = Instantiate(buttonPrefab) as GameObject;
            tutorial.transform.SetParent(buttonContainer);
        }

    }

	public void Tutorial1(){
		SceneManager.LoadScene ("tutorialSolat");		
	}

	/*public void Finish(){
		SceneManager.LoadScene ("finish");		
	}

	public void Home(){
		SceneManager.LoadScene ("main_menu");		
	}

    public void AutoPlay()
    {
        SceneManager.LoadScene("videoTutorial");
    }



    // Update is called once per frame
    void Update () {
		
	}*/
}
