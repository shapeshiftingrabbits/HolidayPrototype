﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveObjectScript : MonoBehaviour {

	Color currentColor;
	Color startColor = Color.white;
	Color endColor = Color.green;

	float currentCompletion;
	float initialCompletion = 0f;
	float finalCompletion = 100f;
	float completionRate = 10f;

	// Use this for initialization
	void Start () {
		currentCompletion = initialCompletion;
	}

	// Update is called once per frame
	void Update () {
		 UpdateColor ();
	}

	public void IncrementCompletion () {
		currentCompletion += completionRate;
	}

	bool IsComplete () {
		return currentCompletion >= finalCompletion;
	}

	public bool IsActivable () {
		return !IsComplete();
	}

	void UpdateColor () {
		currentColor = Color.Lerp(
			startColor,
			endColor,
			currentCompletion / finalCompletion
		);

		gameObject.GetComponent<Renderer>().material.color = currentColor;
	}
}