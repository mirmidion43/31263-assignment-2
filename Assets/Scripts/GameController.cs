using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AudioSource norm;
    public AudioSource walk;
    public AudioSource loader;
    // Start is called before the first frame update
    void Start()
    {
        loadScene1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene1(){
        Invoke("volUp", 4.0f);
        loader.Play();        
    }

    private void volUp()
    {
        norm.Play();
        norm.volume = 0.5f;
        walk.Play();
    }

    public void loadIntro(){
        norm.Stop();
        walk.Stop();
        SceneManager.LoadScene(0);
    }
}

