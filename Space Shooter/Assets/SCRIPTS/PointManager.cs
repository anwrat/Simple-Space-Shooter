using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int score;
    public TMP_Text scoretext;
    public TMP_Text currentscore;
    public TMP_Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: " + 0; //Setting the score to 0 at start of the game
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

    public void HighScoreUpdate()
    {
        //Check if there is already a highscore
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            //If current score is greater than the saved high score
            if (score> PlayerPrefs.GetInt("SavedHighScore")){
                PlayerPrefs.SetInt("SavedHighScore",score);
            }
        }
        else
        {
            //if there is no highscore
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        currentscore.text = "Your score: "+score.ToString();
        highscore.text = "High Score: "+PlayerPrefs.GetInt("SavedHighScore").ToString();
    }
}
