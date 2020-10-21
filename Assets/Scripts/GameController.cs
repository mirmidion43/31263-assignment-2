using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioSource norm;
    public AudioSource scared;
    public AudioSource dead;
    public AudioSource loader;
    public Text countdown;
    private float timer = 0;
    public bool go = false;
    public GameObject panel;
    public UIManager uIManager;

    // Start is called before the first frame update
    void Start()
    {
        loadScene1();
        Invoke("Countdown2", 1.0f);
        Invoke("Countdown1", 2.0f);
        Invoke("Go", 3.0f);
        Invoke("Clear", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(go)
        {
            timer+=Time.deltaTime;
            uIManager.timeUpdate(timer);
        }
    }

    public float getTimer(){
        return timer;
    }

    private void Countdown2(){
        countdown.text = "2";
    }

    private void Countdown1(){
        countdown.text = "1";
    }
    private void Go(){
        countdown.text = "GO!";
    }

    private void Clear(){
        panel.SetActive(false);
        go = true;
    }
    public void loadScene1(){
        Invoke("volUp", 4.0f);
        loader.Play();        
    }

    private void volUp()
    {
        norm.Play();
        norm.volume = 0.5f;
    }

    public void loadIntro(){
        norm.Stop();
        SceneManager.LoadScene(0);
    }

    public void scaredMusic(){
        norm.Pause();
        scared.Play();
    }

    public void stopScared(){
        scared.Stop();
        norm.UnPause();
    }

    public void ghostDied(GhostCollisions ghost){
        scared.volume = 0;
        dead.Stop();
        dead.Play();
        StartCoroutine(dying(ghost));
    }
    IEnumerator dying(GhostCollisions ghost){
        yield return new WaitForSeconds(5.0f);
        scared.volume = 1.0f;
        ghost.Heal();
    }
}

