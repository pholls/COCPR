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

            pressing = 1.0f;
        }
        else
        {
            pressing = 0.0f;
        }

        animator.SetFloat("Pressing", pressing);
    }
}