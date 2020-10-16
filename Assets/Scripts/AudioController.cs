using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource norm;
    public AudioSource walk;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("volUp", 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void volUp()
    {
        norm.volume = 0.5f;
        walk.volume = 0.3f;
    }
}
