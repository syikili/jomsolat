using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

    public GameObject achievementPrefab;
    public Sprite[] sprites;


	// Use this for initialization
	void Start () {
        CreateAchievement("General", "Test Title", "blalalalaa", 24);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateAchievement(string category, string title,string description, int points )
    {
        GameObject achievment = (GameObject)Instantiate(achievementPrefab);
        SetAchievementInfo(category, achievment, title, description, points);
    }

    public void SetAchievementInfo(string category, GameObject achievment, string title, string description, int points )
    {
        achievment.transform.SetParent(GameObject.Find(category).transform);
        achievment.transform.localScale = new Vector3(1, 1, 1);
        achievment.transform.GetChild(0).GetComponent<Text>().text = title;
        achievment.transform.GetChild(1).GetComponent<Text>().text = description;
        achievment.transform.GetChild(2).GetComponent<Text>().text = points.ToString();
        //achievment.transform.GetChild(3).GetComponent<Image>().sprite = sprites[spriteIndex];


    }
}


