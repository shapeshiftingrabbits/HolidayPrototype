using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivateController : MonoBehaviour {

	public List<GameObject> activableGameObjectsInRange;
	private GameObject activableObject;

	// Use this for initialization
	void Start () {
		activableGameObjectsInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") ) {
			activableObject = firstValidActivableGameObject();

			if (activableObject != null)
				activableObject.GetComponent<ActiveableScript>().Deactivate();
		}
	}

	GameObject firstValidActivableGameObject () {
		return activableGameObjectsInRange.Find(
			x => x.GetComponent<ActiveableScript>().IsActivable()
		);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Activable" && !activableGameObjectsInRange.Contains(other.gameObject)) {
			activableGameObjectsInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Activable") {
			activableGameObjectsInRange.Remove(other.gameObject);
		}
	}
}
