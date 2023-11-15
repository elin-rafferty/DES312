using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abertay.Analytics;

public class CameraOut : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private bool cam1Active = true;
    private int CamSwitchTimes = 0;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        AnalyticsManager.Initialise("development");
    }

    // Update is called once per frame
    void Update()
    {
        CamSwitch();

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
            CamSwitchTimes++;

            // Dictionary<string, object> data = new Dictionary<string, object>();
            //data.Add("CamSwitchTimes", CamSwitchTimes);

            //AnalyticsManager.SendCustomEvent("CameraZoomOut", data);

            Color c = Color.blue;
            c.a = 0.4f;
            AnalyticsManager.LogHeatmapEvent("CameraZoomOut", transform.position, c);

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


