using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBump : MonoBehaviour
{
    public AudioSource bump;
    public ParticleSystem bump1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="Wall")
        {
            bump.Play();
            bump1.Play(true); 
        }

        if(other.tag=="Portal1")
            gameObject.transform.position = new Vector3(12.5f,0.5f,0.0f);
        if(other.tag=="Portal2")
            gameObject.transform.position = new Vector3(-12.5f,0.5f,0.0f);
    }


}
