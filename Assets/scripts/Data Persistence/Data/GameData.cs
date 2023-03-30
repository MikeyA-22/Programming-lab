using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int score;
    public Vector3 playerPosition;


    public GameData()
    {
        this.score = 0;
        this.playerPosition = new Vector3(0, 3.5f, 0);

    }
}
