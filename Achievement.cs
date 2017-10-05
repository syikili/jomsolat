 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement  {

    private string name, description;
    private bool unlocked;
    private int points;
    private int spriteIndex;
    private GameObject achievementRef;


    public Achievement(string name, string description, int points, GameObject achievementRef, int spritesIndex)
    {
        this.name = name;
        this.description = description;
        this.unlocked = false;
        this.points = points;
        this.achievementRef = achievementRef;
        this.spriteIndex = spritesIndex;

    }

   /* public bool EarnAchievement()
    {
        if (!unlocked)
        {
            return true;
        }
    }*/

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
