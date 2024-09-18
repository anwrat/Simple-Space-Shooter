using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + score; //Setting the score to 0 at start of the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoretext.text = "Score: " + score;
    }
}
