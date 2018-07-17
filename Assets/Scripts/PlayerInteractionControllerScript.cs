using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionControllerScript : MonoBehaviour {

	public List<GameObject> interactableGameObjectsInRange;
	private GameObject interactableObject;
	private string[] interactableTags = { Constants.Tag.DISTRACTION_OBJECT, Constants.Tag.OBJECTIVE_OBJECT };

	// Use this for initialization
	void Start () {
		interactableGameObjectsInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") ) {
			interactableObject = firstValidInteractableGameObject();

			if (interactableObject != null) {
				interactableObject.GetComponent<IPlayerInteractable>().Interact();
			}
		}
	}

	GameObject firstValidInteractableGameObject () {
		return interactableGameObjectsInRange.Find(
			x => x.GetComponent<IPlayerInteractable>().IsInteractable()
		);
	}

	void OnTriggerEnter(Collider other) {
		if (System.Array.Exists(interactableTags, x => x == other.tag) && !interactableGameObjectsInRange.Contains(other.gameObject)) {
			interactableGameObjectsInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (System.Array.Exists(interactableTags, x => x == other.tag)) {
			interactableGameObjectsInRange.Remove(other.gameObject);
		}
	}
}
