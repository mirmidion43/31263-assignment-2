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
        UIManager uIManager = GameObject.FindWithTag("objectManager").GetComponent<UIManager>();
        uIManager.PelletGet();
        GameObject.Destroy(gameObject);
    }
}
