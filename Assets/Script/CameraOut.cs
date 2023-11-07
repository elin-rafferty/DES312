using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOut : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private bool cam1Active = true;


    public float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CamSwitch();
        /*
        if (Input.GetKeyDown(KeyCode.C))
        {
            time -= Time.deltaTime;
            cam1Active = !cam1Active;
            cam1.SetActive(cam1Active);
            cam2.SetActive(!cam1Active);

            if (time <= 0f)
            {
                time = 5f;
                Debug.Log("Time's up!");

            }
        }*/
    }

    void Counter()
    {
        if (!cam1Active)
        {
            time -= Time.deltaTime;
        }
    }

    void CamSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            cam1Active = !cam1Active;
            cam1.SetActive(cam1Active);
            cam2.SetActive(!cam1Active);
        }
        if (time <= 0f)
        {
            cam1.SetActive(!cam1Active);
            cam2.SetActive(cam1Active);
            time = 5f;
            Debug.Log("Time's up!");
            cam1Active = true;
        }
        Counter();
    }
}


