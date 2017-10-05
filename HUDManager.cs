using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {

    Text scoreText, highscoreText;
    Text levelText;
    GameObject projectileDisplay;
    

	// Use this for initialization
	void Start () {

        scoreText = transform.FindChild("Score").GetComponent<Text>();
        highscoreText = scoreText.transform.FindChild("Highscore").GetComponent<Text>();
        levelText = transform.FindChild("Level").GetComponent<Text>();
        projectileDisplay = transform.FindChild("Projectiles").gameObject;

	}
	

    public void UpdateHUD(int score, int highscore, int level, int numprojectiles)
    {
        scoreText.text = "SCORE\n" + score.ToString();
        if (highscore > 0)
        {
            highscoreText.text = "highscore\n" + highscore.ToString();
            levelText.text = "LEVEL: " + level.ToString();

        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
