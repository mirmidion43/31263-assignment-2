using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public SceneLoader SceneLoader;
    public AudioSource norm;
    public AudioSource walk;
    public AudioSource intro;
    public AudioSource loader;
    // Start is called before the first frame update
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene1(){
        Invoke("volUp", 4.0f);
        intro.Stop();
        loader.Play();        
    }

    void volUp()
    {
        norm.volume = 0.5f;
        walk.Play();
    }

    public void loadScene2(){
        intro.Stop();
    }
}
