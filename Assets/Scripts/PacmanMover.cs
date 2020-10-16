using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMover : MonoBehaviour
{
    //private Tween activeTween;
    private List<Tween> activeTweens = new List<Tween>();
   
    private Tween activeTween = null;
    public GameObject Pacman;
    // Start is called before the first frame update
    void Start()
    {
        addTween(Pacman.transform.position,new Vector3(-7.5f,13.5f,0.0f), 1.0f);
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
        else 
        {
            if(Pacman.transform.position== new Vector3(-12.5f,13.5f,0.0f))
            {
                Pacman.transform.Rotate(new Vector3(0.0f,180.0f,270.0f));
                addTween(Pacman.transform.position,new Vector3(-7.5f,13.5f,0.0f), 1.0f);
            }
            if(Pacman.transform.position== new Vector3(-7.5f,13.5f,0.0f))
            {
                Pacman.transform.Rotate(new Vector3(0.0f,0.0f,90.0f));
                addTween(Pacman.transform.position, new Vector3(-7.5f,9.5f,0.0f), (4.0f/6.0f));
            }
            if(Pacman.transform.position==new Vector3(-7.5f,9.5f,0.0f))
            {
                Pacman.transform.Rotate(new Vector3(0.0f,180.0f,90.0f));
                addTween(Pacman.transform.position, new Vector3(-12.5f,9.5f,0.0f), 1.0f);
            }
            if(Pacman.transform.position==new Vector3(-12.5f,9.5f,0.0f))
            {
                Pacman.transform.Rotate(new Vector3(0.0f,0.0f,270.0f));
                addTween(Pacman.transform.position, new Vector3(-12.5f,13.5f,0.0f), (4.0f/6.0f));
            }
        }

    }
}
