using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTimer : Timer
{	
    // Reference to game objects Sprite Renderer component
    SpriteRenderer rend;

    // Variable to hold value to fade down to.
    // Can be adjusted in inspector with slider
    [Range(0f, 1f)]
    public float fadeToRedAmount = 0f;

    // Variable to hold fading speed
    public float fadingSpeed = 0.05f;

	// Use this for initialization
	void Start()
	{
		endColor = Color.red;
		// Getting Sprite Renderer component
		rend = GetComponent<SpriteRenderer>();

		// Getting access to Color options
		Color c = rend.material.color;

		// Setting initial values for Green and Blue channels
		c.g = 1f;
		c.b = 1f;

		// Set sprite colors
		rend.material.color = c;
		//StartFadeToRed();
	}

	// Coroutine to slowly fade down to desireable color
	IEnumerator FadeToRed()
	{
		// Loop that runs from 1 down to desirable Red Channel Color amount
		for (float i = 1f; i >= fadeToRedAmount; i -= 0.05f)
		{
			// Getting access to Color options
			Color c = rend.material.color;

			// Setting values for Green and Blue channels
			c.g = i;
			c.b = i;

			// Set color to Sprite Renderer
			rend.material.color = c;

			// Pause to make color be changed slowly
			yield return new WaitForSeconds(fadingSpeed);
		}
	}

	// Method that starts fading coroutine when UI button is pressed
	public void StartFadeToRed()
	{
		StartCoroutine("FadeToRed");
	}

	public override void AddTime()
	{
		transform.position += transform.right;
		transform.localScale += transform.right;
		AdjustColor("Green");
	}

	public override void IncrementTimer()
	{
		// these two together shrink the healthbar into the leftmost spot of its
		// starting position
		// move healthbar to the left at constant rate (half of travelSpeed)
		transform.position -= transform.right * travelSpeed * 0.5f * Time.deltaTime;
		// shrink healthbar toward the middle at constant rate
		transform.localScale -= transform.right * travelSpeed * Time.deltaTime;
		this.AdjustColor("Red");
	}

	void AdjustColor(string direction)
	{
		// if direction is "Green"
		// if bar is over halfway full
		// add green
		// else
		// subtract red
		// if direction is "Red"
		// if bar is over halfway full
		// subtract green
		// else
		// add red
		// else
		// do nothing
	}
}
