using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAudioController : MonoBehaviour
{
    public SceneLoader SceneLoader;
    public AudioSource intro;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene1(){
        intro.Stop();       
    }

    public void loadScene2(){
        intro.Stop();
    }

    public void loadIntro(){
        intro.Play();
    }
}
