using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	public Transform camTransform;
    private Vector3 position;

	Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
        position = transform.parent.position - transform.position;
    }

    void Update()
    {
     	transform.rotation = camTransform.rotation * originalRotation;
         transform.position = transform.parent.position - position; 
    }
}