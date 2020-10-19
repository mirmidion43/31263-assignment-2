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
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            text.SetActive(true);
        }
    }

    public void loadIntro(){
        SceneManager.LoadScene(0);
        gameController.loadIntro();
    }

    public void PelletGet() {
        pickup.Play();
        scoreInt += 10;
        score.GetComponent<Text>().text = "" + scoreInt;
    }

    public void CherryGet() {
        scoreInt += 100;
        score.GetComponent<Text>().text = "" + scoreInt;
    }
}
