using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Data
{
    public int score;
    public int level;

    public Data(GameManager gm)
    {
        level = gm.level;
        score = gm.score;
    }

    
}
