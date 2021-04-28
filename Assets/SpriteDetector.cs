using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SpriteDetector : MonoBehaviour
{
    private float pressing = 0;
    public Animator animator;
    private float timeSinceLastTouch;
    public Timer healthBarTimer;
    public GameObject okaySprite;
    public GameObject lateSprite;
    public GameObject earlySprite;
    public GameObject perfectSprite;

    void Start()
    {
        addPhysics2DRaycaster();
        animator = GetComponent<Animator>();
        timeSinceLastTouch = 0.0f;
    }

    void addPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = GameObject.FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            pressing = 1.0f;
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Debug.Log("Touch Pressed");

                // evaluate timing
                EvaluateTiming(timeSinceLastTouch);

                // reset timer
                timeSinceLastTouch = 0.0f;
            }
        }
        else
        {
            pressing = 0.0f;
            // add time
            timeSinceLastTouch += Time.deltaTime;
            //if (timeSinceLastTouch > 0.65f)
            //{
            //    // subtract time from health bar timer
            //    healthBarTimer.AddTime(-0.01f);

            //    StartCoroutine(ShowSprite(lateSprite));
            //}
        }

        animator.SetFloat("Pressing", pressing);
    }

    private void EvaluateTiming(float time)
    {
        if (time >= 0.45 && time <= 0.65) // perfect
        {
            healthBarTimer.AddTime(0.5f);

            StartCoroutine(ShowSprite(perfectSprite));
        }
        //else if (
        //    time >= 0.3 && time < 0.4 || // slightly too fast
        //    time >= 0.6 && time <= 0.7 // slightly too slow
        //)
        //{
        //    healthBarTimer.AddTime(0.1f);

        //    StartCoroutine(ShowSprite(okaySprite));
        //}
        else // early or late
        {
            // subtract time from health bar timer
            healthBarTimer.AddTime(-0.01f);

            StartCoroutine(ShowSprite(earlySprite));
        }
    }

    public IEnumerator ShowSprite(GameObject sprite)
    {
        // disable all sprites
        okaySprite.GetComponent<Renderer>().enabled = false;
        lateSprite.GetComponent<Renderer>().enabled = false;
        earlySprite.GetComponent<Renderer>().enabled = false;
        perfectSprite.GetComponent<Renderer>().enabled = false;

        Renderer spriteRenderer = sprite.GetComponent<Renderer>();
        spriteRenderer.enabled = true;           //show
        yield return new WaitForSeconds(0.25f);  //wait
        spriteRenderer.enabled = false;          //hide
    }

}