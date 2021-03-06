﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveObjectScript : MonoBehaviour, IPlayerInteractable {

	Color currentColor;
	Color startColor = Color.white;
	Color endColor = Color.green;

	float currentCompletion;
	float initialCompletion = 0f;
	float finalCompletion = 100f;
	float completionRate = 10f;

	public GameObject interactionPrompt;
	Vector3 interactionPromptOffset = new Vector3(0, 65, 0);

	GameObject canvas;
	public GameObject completionSliderPrefab;
	GameObject completionSlider;
	Vector3 completionSliderPositionOffset = new Vector3(0, -45, 0);

	// Use this for initialization
	void Start () {
		currentCompletion = initialCompletion;

		canvas = GameObject.Find("Canvas");
		completionSlider = Instantiate(completionSliderPrefab, canvas.transform);

		completionSlider.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position) + completionSliderPositionOffset;
		completionSlider.GetComponent<Slider>().minValue = initialCompletion;
		completionSlider.GetComponent<Slider>().maxValue = finalCompletion;
	}

	// Update is called once per frame
	void Update () {
		 UpdateColor ();
	}

	public void Interact () {
		currentCompletion += completionRate;

		completionSlider.GetComponent<Slider>().value = currentCompletion;
	}

	public bool IsComplete () {
		return currentCompletion >= finalCompletion;
	}

	public bool IsInteractable () {
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

	public void ShowInteractionPrompt () {
		interactionPrompt.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position) + interactionPromptOffset;

		interactionPrompt.SetActive(true);
	}

	public void HideInteractionPrompt () {
		interactionPrompt.SetActive(false);
	}
}
