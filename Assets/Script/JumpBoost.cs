using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class JumpBoost : MonoBehaviour
{

    public Stamina staminaScript;

    public float speed = 2.0f;
    public float currentMoveSpeed;
    public float jumpSpeed = 8.0f;

    private float currentJumpSpeed;

    public float gravity = 20.0f;
    private float currentGravity;

    public float friction = 6.0f;
    private float currentFrition;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "jumpBoost":
                jumpSpeed = 40f;
                break;
            case "Ground":
                jumpSpeed = currentJumpSpeed;
                speed = currentMoveSpeed;
                break;


        }
    }
}
