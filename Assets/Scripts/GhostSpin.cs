using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpin : MonoBehaviour
{
    private Tween activeTween = null;

    // Start is called before the first frame update
    void Start()
    {
        //addTween(gameObject.transform.position,new Vector3(-12.0f,-1.0f,0.0f), 2.0f);
    }

    public void addTween(Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
            activeTween = new Tween(gameObject.transform, startPos, endPos, Time.time, duration);
    }

    // Update is called once per frame
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
            if(gameObject.transform.position== new Vector3(-12.0f,-1.0f,0.0f))
                addTween(gameObject.transform.position,new Vector3(-12.0f,11.6f,0.0f), 2.0f);
            if(gameObject.transform.position== new Vector3(12f,-1.0f,0.0f))
                addTween(gameObject.transform.position, new Vector3(-12.0f,-1.0f,0.0f), 2.0f);
            if(gameObject.transform.position==new Vector3(12f,11.6f,0.0f))
                addTween(gameObject.transform.position, new Vector3(12.0f,-1.0f,0.0f), 2.0f);
            if(gameObject.transform.position==new Vector3(-12f,11.6f,0.0f))
                addTween(gameObject.transform.position, new Vector3(12.0f,11.6f,0.0f), 2.0f);


            if(gameObject.transform.position== new Vector3(-10.0f,-3.0f,0.0f))
                addTween(gameObject.transform.position,new Vector3(10.0f,-3.0f,0.0f), 2.0f);
            if(gameObject.transform.position== new Vector3(10.0f,-3.0f,0.0f))
                addTween(gameObject.transform.position, new Vector3(10.0f,-9.5f,0.0f), 2.0f);
            if(gameObject.transform.position==new Vector3(10.0f,-9.5f,0.0f))
                addTween(gameObject.transform.position, new Vector3(-10.0f,-9.5f,0.0f), 2.0f);
            if(gameObject.transform.position==new Vector3(-10.0f,-9.5f,0.0f))
                addTween(gameObject.transform.position, new Vector3(-10.0f,-3.0f,0.0f), 2.0f);
        }
    }
}
