using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour {   

    public RoundData[] allRoundData;

	// Use this for initialization
	void Start () {

        //MyMethod();
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("LetsStartQuiz");
	}

    public RoundData GetCurentRoundData()
    {
        return allRoundData[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 5seconds");
        yield return new WaitForSeconds(5);
        Debug.Log("After Waiting 5 Seconds");
    }
}
