using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string nameCollectable;
    public int score;
   

    public Collectable(string name, int scorevalue)
    {
        this.nameCollectable = name;
        this.score = scorevalue;
        
    }

    public void UpdateScore()
    {
        ScoreManager.scoremanager.UpdateScore(score);
    }

  
}
