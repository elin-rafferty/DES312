using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time = 30f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f)
        {
            Debug.Log("Time's up!");
        }
    }
}
