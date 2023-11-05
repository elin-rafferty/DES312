using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=pyb3cKrj1ZE

public class Camera : MonoBehaviour
{

    public Transform targetObject;
    public Vector3 cameraOffset;
    public bool lookAtTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = newPosition; 

        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}
