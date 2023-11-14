using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Zs2zgOMizfo

public class WallClimbScript : MonoBehaviour
{
    public float open = 100f;
    public float range = 3f;
    public bool TouchWall = false;
    public float ClimbSpeed = 7f;
    public GameObject character;
    public CharacterMovement movementScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        if (Input.GetKey(KeyCode.W) & TouchWall == true && movementScript.stamina > 0)
        {
            transform.position += Vector3.up * Time.deltaTime * ClimbSpeed;
            GetComponent<Rigidbody>().isKinematic = true;
            TouchWall = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            TouchWall = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(character.transform.position, character.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                TouchWall = true;
            }
        }
    }
}