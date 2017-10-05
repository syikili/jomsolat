using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl: MonoBehaviour {



    public const int NumWorlds = 3;
    public const int NumLevels = 20;
    public List<GameWorlds> AllWorlds;
    public GameWorlds CurrWorld
    {
        set { currWorld = value; Debug.Log("Current world set."); }
        get
        {
            if (currWorld != null)
                return currWorld;
            else
            {
                Debug.Log("Can't retrieve current world. Value is null.");
                return null;
            }
        }
    }
    public GameLevels CurrLevel
    {
        set { currLevel = value; Debug.Log(value); }
        get
        {
            if (currLevel != null)
            {
                
                return currLevel;
            }
            else
            {
                Debug.Log("Can't retrieve current level. Value is null.");
                return null;
            }
        }
    }

    [SerializeField]
    Game gamePrefab;

    public Game CurrentGame;

    private GameLevels currLevel;
    private GameWorlds currWorld;

    void CheckForCurrentGameOver()
    {
        if (CurrentGame.currLevelObj == null && CurrentGame.gameOver)
        {
            Destroy(CurrentGame.gameObject);
            Debug.Log("Game Over!");
        }
    }
    public void StartGame(int level)
    {
        CurrentGame = Instantiate(gamePrefab) as Game;
        CurrentGame.gameObject.name = "Game";

        CurrentGame.InitLevel(level, 3);
    }


    // Use this for initialization
    void Start () {

        //StartGame(0);

        AllWorlds = new List<GameWorlds>();
        for (int i = 0; i<NumWorlds; i++)
        {
            AllWorlds.Add(new GameWorlds());
        }
        // StartGame(0);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentGame != null)
        {
            CheckForCurrentGameOver();
        }
    }
}
