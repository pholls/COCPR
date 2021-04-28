using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbulanceTimer : Timer
{

    //public float endX = -11.5f;

    // Use this for initialization
    void Start()
    {
        endColor = Color.green;
    }

    public override void IncrementTimer()
    {
        transform.position -= transform.right * travelSpeed * Time.deltaTime;
    }

    public override void LoadScene()
    {
        SceneManager.LoadScene("EMSMode");
    }
}
