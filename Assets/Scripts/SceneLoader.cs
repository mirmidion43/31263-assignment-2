using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public IntroAudioController audioController;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel1(){        
        SceneManager.LoadScene(1);
    }

    public void loadLevel2(){
        SceneManager.LoadScene(2);
    }

    public void closeGame(){
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
