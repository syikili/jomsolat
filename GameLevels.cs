using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevels {

    public GameLevels ()
    {
        highscore = 0;
        currentscore = 0;
        unlocked = false;
        OneStarReq = 100;
        TwoStarReq = 200;
        ThreeStarReq = 300;

    }

    public int OneStarReq, TwoStarReq, ThreeStarReq;
    public bool Defeated
    {
        get
        {
            if (Highscore > OneStarReq)

            return true;
            return false;

        }
    }
    public int CurrStarScore
    {
        get
        {
            if (Currentscore >= ThreeStarReq)
                return 3;
            if (Currentscore >= TwoStarReq)
                return 2;
            if (Currentscore >= OneStarReq)
                return 1;
            return 0;
        }
    }
    public int HighStarScore
    {
        get
        {
            if (Highscore >= ThreeStarReq)
                return 3;
            if (Highscore >= TwoStarReq)
                return 2;
            if (Highscore >= OneStarReq)
                return 1;
                return 0;
        }
    }

    public int Highscore
    {
        get
        {
            return highscore;
        }

        set
        {
            highscore = value;
        }
    }

    public int Currentscore
    {
        get
        {
            return currentscore;
        }

        set
        {
            currentscore = value;
        }
    }

    public bool Unlocked
    {
        get
        {
            return unlocked;
        }

        set
        {
            unlocked = value;
        }
    }

    private int highscore, currentscore;
    private bool unlocked;
}
