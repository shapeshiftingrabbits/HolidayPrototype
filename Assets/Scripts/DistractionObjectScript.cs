using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractionObjectScript : MonoBehaviour, IPlayerInteractable {

	Color currentColor;
	Color deactivatedColor = Color.grey;
	Color activatedStartColor = Color.yellow;
	Color activatedEndColor = Color.red;
	Color failedColor = Color.black;

	float lastActivated = 0f;
	float activationRate = 2f;
	float currentActivationTime = 0f;
	float activationMaximumTime = 5f;

	public GameObject interactionPrompt;
	Vector3 interactionPromptOffset = new Vector3(0, 65, 0);

	// Use this for initialization
	void Start () {
		currentColor = deactivatedColor;
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

	public bool IsFailed () {
		return currentActivationTime >= activationMaximumTime;
	}

	public bool IsInteractable() {
		return (IsActive() && !IsFailed());
	}

	void Activate() {
		lastActivated = 0f;
		currentActivationTime = 0.1f;
	}

	public void Interact() {
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

	public void ShowInteractionPrompt () {
		interactionPrompt.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position) + interactionPromptOffset;

		interactionPrompt.SetActive(true);
	}

	public void HideInteractionPrompt () {
		interactionPrompt.SetActive(false);
	}
}
