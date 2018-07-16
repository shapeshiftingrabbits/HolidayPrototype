using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveableScript : MonoBehaviour {

	Color currentColor = Color.white;
	Color deactivatedColor = Color.white;
	Color activatedStartColor = Color.yellow;
	Color activatedEndColor = Color.red;
	Color failedColor = Color.black;

	float lastActivated = 0f;
	float activationRate = 5f;
	float currentActivationTime = 0f;
	float activationMaximumTime = 10f;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = deactivatedColor;
	}

	// Update is called once per frame
	void Update () {
		if (IsActive()) {
			currentActivationTime += Time.deltaTime;
		}
		else if (!IsActive() && IsReadyToActivate()) {
			Activate();
		}
		else {
			lastActivated += Time.deltaTime;
		}

		UpdateColor();
	}

	bool IsReadyToActivate() {
		return (lastActivated >= activationRate);
	}

	bool IsActive () {
		return currentActivationTime > 0f;
	}

	bool IsFailed () {
		return currentActivationTime >= activationMaximumTime;
	}

	void Activate() {
		lastActivated = 0f;
		currentActivationTime = 0.1f;
	}

	void Deactivate() {
		currentActivationTime = 0f;
	}

	void UpdateColor() {
		if (IsFailed()) {
			currentColor = failedColor;
		}
		else if (!IsActive()) {
			currentColor = deactivatedColor;
		}
		else {
			currentColor = Color.Lerp(
				activatedStartColor,
				activatedEndColor,
				currentActivationTime / activationMaximumTime
			);
		}

		gameObject.GetComponent<Renderer>().material.color = currentColor;
	}
}
