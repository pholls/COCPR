using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class SpriteDetector : MonoBehaviour
{
    private float pressing = 0;
    public Animator animator;
    void Start()
    {
        addPhysics2DRaycaster();
        animator = GetComponent<Animator>();
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
            Touch touch = Input.GetTouch(0);

            //animator.SetBool("Press", true);
            pressing = 1.0f;
            Debug.Log("pressing");
        }
        else
        {
            //animator.SetBool("Press", false);
            pressing = 0.0f;
            //Debug.Log("not pressing");
        }

        animator.SetFloat("Pressing", pressing);
    }
    //public void OnMouseDown()
    //{
    //    Debug.Log("Mouse Down");
    //    // switch chest sprite to "compressed"
    //    animator.SetBool("Press", true);
    //    // adjust HealthBarTimer appropriately
    //}

    //public void OnMouseUp()
    //{
    //    Debug.Log("Mouse Up");

    //    // switch chest sprite to "regular"
    //    animator.SetBool("Press", false);
    //}
}