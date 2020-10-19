using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollision : MonoBehaviour
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
        if(other.tag=="Pacman")
        {
            GameObject manager = GameObject.FindWithTag("objectManager");
            UIManager uIManager = manager.GetComponent<UIManager>();
            uIManager.CherryGet();
            CherryController cherryController = manager.GetComponent<CherryController>();
            cherryController.clearTween();
            GameObject.Destroy(gameObject);
        }
        
    }

}
