using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorlds
{

    public GameWorlds()
    {
        gamelevels = new List<GameLevels>();
        for (int i =0; i <TotalLevels;i++)
        {
            gamelevels.Add(new GameLevels());
        }
    }

    private List<GameLevels> gamelevels;
    public List<GameLevels> GameLevels { get { return gamelevels; } set { gamelevels = value; } }
    public int TotalLevels { get { return GameControl.NumLevels; } }
    public int TotalDefeated
    {
        get
        {
            int count = 0;
            for (int i = 0; i < TotalLevels; i++)
            {
                if (gamelevels[i].Defeated)
                    count++;
            }
            return count;
        }



    }
    public int TotalStars
    {
        get
        {
            int count = 0;
            for (int i = 0; i < TotalLevels; i++)
            {
                count += gamelevels[i].HighStarScore;
            }
            return count;
        }



    }
    public int TotalScore
    {
        get
        {
            int count = 0;
            for (int i = 0; i < TotalLevels; i++)
            {
                count += gamelevels[i].Highscore;
            }
            return count;
        }



    }
}
