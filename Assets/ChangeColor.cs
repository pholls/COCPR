using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer sprnd;
    private Color lerpedColor = Color.white;
    // Start is called before the first frame update
    void Start()
    {
        //Get my spriterenderer component
        sprnd = GetComponent<SpriteRenderer>();
        //Save the default spriterenderer color 
        lerpedColor = sprnd.color;
    }

    // Update is called once per frame
    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }
}
