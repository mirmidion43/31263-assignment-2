using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletPickup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Pacman" && !other.isTrigger)
        {
            UIManager uIManager = GameObject.FindWithTag("objectManager").GetComponent<UIManager>();
            if(TryGetComponent(out Animator anim))
            {
                uIManager.PelletGet(10);
                uIManager.Scared();
            //pick up pow pellet code
            }
            else
                uIManager.PelletGet(0);
                GameObject.Destroy(gameObject);
        }
        
    }
}
