using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public bool moving = true;
    public float travelSpeed = 2.0f;
    public Color endColor;

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            this.IncrementTimer();
        }
    }

    public void StopMoving()
    {
        moving = false;
        //Debug.Log("transform.position: " + transform.position);
        //Debug.Log("transform.localScale: " + transform.localScale);
        this.LoadScene();
    }

    public virtual void IncrementTimer()
    { }
    public virtual void AddTime()
    { }
    public virtual void LoadScene()
    { }

}
