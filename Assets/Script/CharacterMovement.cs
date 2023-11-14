using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://learnictnow.com/topics/game-design/unity/moving-a-player-gameobject-with-wasd/
//https://discussions.unity.com/t/how-to-move-the-character-using-wasd/190362/4

public class CharacterMovement : MonoBehaviour
{
    [Header("Refrences")]
    public LayerMask groundLayer;
    Rigidbody rb;
    public Transform groundCheckPos;
    public LayerMask jumpLayer;
    public LayerMask jumpBoostLayer;
    public Transform jumpCheckPos;


    private Vector3 jump = Vector3.up;
    [Header("Movement")]
    public float jumpForce = 8.0f;
    public float jumpBoostForce = 8.0f;

    private bool Ground;

    public float speed = 2.0f;
    private float currentMoveSpeed;


    public float gravity = 20.0f;
    private float currentGravity;

    public float friction = 6.0f;
    private float currentFrition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
   
        currentMoveSpeed = speed;
    }

    // Update is called once per frame
  
    public GameObject character;

 

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !IsOnJumpBoost())
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
        else if ((Input.GetKeyDown(KeyCode.Space) && IsGrounded() && IsOnJumpBoost()))
        {
            rb.AddForce(jump * jumpBoostForce, ForceMode.Impulse);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "jumpBoost")
    //        {
    //            jumpForce = 50f;
    //                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
    //                {

    //                    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
    //                }
    //    }
        
    //}

    private bool IsGrounded()
    {
        if (Physics.CheckSphere(groundCheckPos.position, 0.4f, groundLayer) || (Physics.CheckSphere(jumpCheckPos.position, 0.4f, jumpLayer)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool IsOnJumpBoost()
    {
        if ( (Physics.CheckSphere(jumpCheckPos.position, 0.4f, jumpBoostLayer)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public MovementState state;

    public enum MovementState
    {
        freeze,
        unlimited,

    }

    public bool freeze;
    public bool unlimited;
    public bool restricted;

    private void StateHandler()
    {
        if (freeze)
        {
            state = MovementState.freeze;
            rb.velocity = Vector3.zero;
        }

        else if (unlimited)
        {
            state = MovementState.unlimited;
            speed = 999f;
            return;
        }
    }

    private void MovePlayer()
    {
        if (restricted) return;
    }

    private void Collision(Collider col)
    {
        if (col.gameObject.tag == "Trigger")
        {
            Debug.Log("working");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            SceneManager.LoadScene(sceneName: "Ending");
        }

    }


}


