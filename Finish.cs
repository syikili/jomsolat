using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Finish : MonoBehaviour {
    public Button finish;
    // Use this for initialization
    void Start () {

        finish = finish.GetComponent<Button>();

    }

    public void Finish1()
    {
        SceneManager.LoadScene("Main_menu");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
