using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject text;
    public GameObject score;
    public Text timer;
    public GameController gameController;
    public AudioSource pickup;
    private int scoreInt = 0;
    public GameObject[] lives;
    private int lifeCounter;
    public Text finalScore;
    public Text finalTime;
    public GameObject endScreen;
    public PacStudentController pacStudentController;
    public CherryController cherryController;
    public int pelletsLeft = 222;
    public GameObject[] ghosts;
    public int ghostCounter = 10;
    private float count = 10;
    public Text countdown;
    public int highScore = 0;
    public float BestTime = 0.0f;
    string highScoreKey = "HighScore";
    string timeScoreKey = "BestTime";

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey,0);
        BestTime = PlayerPrefs.GetFloat(timeScoreKey,0.0f);
        text.SetActive(false);
        lifeCounter = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(text.activeSelf)
        {
            count -= Time.deltaTime;
            if(count<ghostCounter - 1)
            {
                ghostCounter-=1;
                countdown.text = "" + ghostCounter;
            }
            if(ghostCounter == 3)
                foreach(GameObject ghost in ghosts)
                    ghost.GetComponent<Animator>().SetBool("Recovering", true);
            if(ghostCounter == 0)
            {
                foreach(GameObject ghost in ghosts)
                {
                    ghost.GetComponent<Animator>().SetBool("Scared", false);
                    ghost.GetComponent<GhostCollisions>().scared = false;
                    gameController.stopScared();
                }
                    
                text.SetActive(false);
            }
                
        }
    }

    public void Scared(){
        ghostCounter = 10;
        count = 10;
        text.SetActive(true);
        countdown.text= "" + ghostCounter;
        gameController.scaredMusic();
        
        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Animator>().SetBool("Recovering",false);
            ghost.GetComponent<Animator>().SetBool("Scared", true);
            ghost.GetComponent<GhostCollisions>().scared = true;
        }
    }

    public void loadIntro(){
        SceneManager.LoadScene(0);
        gameController.loadIntro();
    }

    public void PelletGet( int pow) {
        pickup.Play();
        pelletsLeft -= 1;
        scoreInt += 10 - pow;
        score.GetComponent<Text>().text = "" + scoreInt;
        if(pelletsLeft == 0)
            gameOver();
    }

    public void CherryGet() {
        scoreInt += 100;
        score.GetComponent<Text>().text = "" + scoreInt;
    }

    public void GhostGet(){
        scoreInt+=300;
        score.GetComponent<Text>().text = "" + scoreInt;
    }

    public void timeUpdate(float time) {
        float minutes = Mathf.FloorToInt(time/60);
        float seconds = Mathf.FloorToInt(time%60);
        float milliseconds = (time%1) * 100;

        timer.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void loseLife(){
        lives[lifeCounter].SetActive(false);
        lifeCounter -= 1;
        if(lifeCounter <0)
            gameOver();
    }

    private void gameOver(){
        StartCoroutine("endGame");
        pacStudentController.clearMovement();
        cherryController.stopSpawn();
        gameController.go = false;
        finalScore.text = score.GetComponent<Text>().text;
        finalTime.text = timer.text;
        //stop ghost movement
        endScreen.SetActive(true);

        //save score and shit
        if(scoreInt > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, scoreInt);
            PlayerPrefs.SetFloat(timeScoreKey, gameController.getTimer());
            PlayerPrefs.Save();
        }
        if(scoreInt==highScore && BestTime > gameController.getTimer())
        {
            PlayerPrefs.SetInt(highScoreKey, scoreInt);
            PlayerPrefs.SetFloat(timeScoreKey, gameController.getTimer());
            PlayerPrefs.Save();
        }

    }

    IEnumerator endGame() {
        yield return new WaitForSeconds(3.0f);
        gameController.loadIntro();
    }
}
