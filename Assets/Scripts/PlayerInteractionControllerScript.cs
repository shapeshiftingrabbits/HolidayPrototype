using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionControllerScript : MonoBehaviour {

	public List<GameObject> interactableGameObjectsInRange;
	private GameObject currentInteractableObject;
	private string[] interactableTags = { Constants.Tag.DISTRACTION_OBJECT, Constants.Tag.OBJECTIVE_OBJECT };

	// Use this for initialization
	void Start () {
		interactableGameObjectsInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		RefreshCurrentInteractableObject();

		if (Input.GetButtonDown("Fire1") ) {
			if (currentInteractableObject != null) {
				currentInteractableObject.GetComponent<IPlayerInteractable>().Interact();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (System.Array.Exists(interactableTags, x => x == other.tag) && !interactableGameObjectsInRange.Contains(other.gameObject)) {
			interactableGameObjectsInRange.Add(other.gameObject);
			RefreshCurrentInteractableObject();
		}
	}

	void OnTriggerExit(Collider other) {
		if (System.Array.Exists(interactableTags, x => x == other.tag)) {
			interactableGameObjectsInRange.Remove(other.gameObject);
			RefreshCurrentInteractableObject();
		}
	}

	void RefreshCurrentInteractableObject() {
		currentInteractableObject = interactableGameObjectsInRange.Find(
			x => x.GetComponent<IPlayerInteractable>().IsInteractable()
		);
	}
}
