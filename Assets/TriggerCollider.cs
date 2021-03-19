using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{

    private SpriteRenderer sprnd;
    private Color startColor;
    public Timer timerObject;

    // Start is called before the first frame update
    void Start()
    {
        //Get my spriterenderer component
        sprnd = GetComponent<SpriteRenderer>();
        //Save the default spriterenderer color 
        startColor = sprnd.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Overlapping a collider 2D
    private void OnTriggerStay2D(Collider2D collision)
    {
        sprnd.color = timerObject.endColor;
        timerObject.StopMoving();
    }

    //Just stop overlapping a collider 2D
    private void OnTriggerExit2D(Collider2D collision)
    {
        sprnd.color = startColor;
    }
}
