using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscores : MonoBehaviour
{
    public Text highScoreBoards;
    public Text bestTimeBoard;
    public int highScore;
    public float bestTime;
    string highScoreKey = "HighScore";
    string timeScoreKey = "BestTime";
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        bestTime = PlayerPrefs.GetFloat(timeScoreKey,0.0f);
        highScoreBoards.text = "" + highScore;
        timeUpdate(bestTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void timeUpdate(float time) {
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);
        float milliseconds = (time%1) * 100;

        bestTimeBoard.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
