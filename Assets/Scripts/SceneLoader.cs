using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public AudioController audioController;
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
        audioController.loadScene1();
    }

    public void loadLevel2(){
        SceneManager.LoadScene(2);
        audioController.loadScene2();
    }
}
