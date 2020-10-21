using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCollisions : MonoBehaviour
{
    public PacStudentController pacman;
    public AudioSource scream;
    public ParticleSystem explosion;
    public GameController gameController;
    public bool scared = false;
    public UIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Pacman" && !other.isTrigger)
        {
            if(!scared)
            {
                Time.timeScale = 0;
                pacman.clearMovement();
                scream.Play();
                explosion.Play();
                pacman.respawnPacman();
            }
            if(scared)
            {
                gameController.ghostDied(this);
                uIManager.GhostGet();
                gameObject.GetComponent<Animator>().SetBool("dying", true);
                gameObject.GetComponent<Animator>().SetBool("Scared", false);
                gameObject.GetComponent<Animator>().SetBool("Recovering", false);
            }
        }
    }
    public void Heal(){
        gameObject.GetComponent<Animator>().SetBool("dying", false);
        scared = false;
    }
}
