using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioSource norm;
    public AudioSource loader;
    public Text countdown;
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
        
    }

    private void Countdown2(){
        countdown.text = "2";
    }

    private void Countdown1(){
        countdown.text = "1";
    }
    private void Go(){
        countdown.text = "Go!";
    }

    private void Clear(){
        countdown.enabled = false;
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
}

