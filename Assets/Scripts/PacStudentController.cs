using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
   
    private Tween activeTween = null;
    public GameObject Pacman;
    private string lastInput = null;
    private string currentInput = null;
    public AudioSource walk;
    public bool isWalking = false;
    public Animator pacAnimator;
    public ParticleSystem dust;
    private bool isIntro = true;
    public BoxCollider probe;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitIntro", 4.0f);
    }
    public void addTween(Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
            activeTween = new Tween(Pacman.transform, startPos, endPos, Time.time, duration);
    }

    void Update()
    {
        
        if(activeTween != null)
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);

            if(distance > 0.1f)
                {
                    float t = (Time.time - activeTween.StartTime) / activeTween.Duration;
                    activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);
                    
                }
        
                if(distance <= 0.1f)
                {
                    activeTween.Target.position = activeTween.EndPos;
                    activeTween = null;
                } 

        }

        if(!isIntro)
        {
            if(Input.GetKeyDown(KeyCode.D))
                lastInput = "d";
            if(Input.GetKeyDown(KeyCode.A))
                lastInput = "a";
            if(Input.GetKeyDown(KeyCode.W))
                lastInput = "w";
            if(Input.GetKeyDown(KeyCode.S))
                lastInput = "s";
        }
        
            
        movePacman();

        //if(!isWalking)
          //  probe.enabled = true;
        //else
          //  probe.enabled = false;

        if(isWalking && !walk.isPlaying)
        {
            walk.Play();
            pacAnimator.enabled=true;
            dust.Play();
        }
            
        if(!isWalking && walk.isPlaying)
        {
            walk.Stop();
            pacAnimator.enabled=false;
            dust.Stop();
        }

    }

    private void movePacman(){
        if(activeTween==null)
        {
            if(lastInput == "d")
                MoveRight(1); 
            if(lastInput == "a")
                MoveLeft(1);
            if(lastInput == "w")
                MoveUp(1);
            if(lastInput == "s")
                MoveDown(1); 
        }
        if(activeTween==null)
        {
            if(currentInput == "d")
                MoveRight(0); 
            if(currentInput == "a")
                MoveLeft(0);
            if(currentInput == "w")
                MoveUp(0);
            if(currentInput == "s")
                MoveDown(0); 
        }
        if(activeTween!=null)
            isWalking=true;
        else
            isWalking=false;
    }

    private void MoveRight(int check) {
        int layerMask = 1<<8;
        layerMask= ~layerMask;
        if(!Physics.CheckSphere(new Vector3(Pacman.transform.position.x + 1.0f,Pacman.transform.position.y,0.0f), 0.1f,layerMask))
        {
            addTween(Pacman.transform.position,new Vector3(Pacman.transform.position.x + 1.0f,Pacman.transform.position.y,0.0f), 0.2f);
            Pacman.transform.rotation = (new Quaternion(0.0f,180.0f,0.0f,0.0f));
            if(check == 1)
                currentInput = lastInput;
        }
        

    }
    private void MoveLeft(int check) {
        int layerMask = 1<<8;
        layerMask= ~layerMask;
        if(!Physics.CheckSphere(new Vector3(Pacman.transform.position.x - 1.0f,Pacman.transform.position.y,0.0f), 0.1f,layerMask))
        {
            addTween(Pacman.transform.position,new Vector3(Pacman.transform.position.x - 1.0f,Pacman.transform.position.y,0.0f), 0.2f);
            Pacman.transform.rotation = (new Quaternion(0.0f,0.0f,0.0f,0.0f));
            if(check == 1)
                currentInput = lastInput;
        }
        

    }
    private void MoveUp(int check) {
        int layerMask = 1<<8;
        layerMask= ~layerMask;
        if(!Physics.CheckSphere(new Vector3(Pacman.transform.position.x,Pacman.transform.position.y + 1.0f,0.0f), 0.1f,layerMask))
        {
            addTween(Pacman.transform.position,new Vector3(Pacman.transform.position.x,Pacman.transform.position.y + 1.0f,0.0f), 0.2f);
            Pacman.transform.rotation = (new Quaternion(0.0f,0.0f,0.0f,0.0f));
            Pacman.transform.Rotate(new Vector3(0.0f,0.0f,270.0f));
            if(check == 1)
                currentInput = lastInput;
        }
        

    }
    private void MoveDown(int check) {
        int layerMask = 1<<8;
        layerMask= ~layerMask;
        if(!Physics.CheckSphere(new Vector3(Pacman.transform.position.x,Pacman.transform.position.y-1.0f,0.0f), 0.1f,layerMask))
        {
            addTween(Pacman.transform.position,new Vector3(Pacman.transform.position.x,Pacman.transform.position.y - 1.0f,0.0f), 0.2f);
            Pacman.transform.rotation = (new Quaternion(0.0f,180.0f,0.0f,0.0f));
            Pacman.transform.Rotate(new Vector3(0.0f,0.0f,90.0f));
            if(check == 1)
                currentInput = lastInput;
        }
        

    }

    private void WaitIntro(){
        isIntro = false;
    }
}
