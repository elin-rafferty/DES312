using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Zs2zgOMizfo

public class Target : MonoBehaviour
{
    public float climbSpeed = 2f;

    public void Tstart()
    {

    }

    public void Commence(float amount)
    {
        climbSpeed -= amount;
        if (climbSpeed <= 0f)
        {
            Go();
        }
    }
    void Go()
    {
        Destroy(gameObject);
    }


}
