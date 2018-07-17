using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivateController : MonoBehaviour {

	public List<GameObject> activableGameObjectsInRange;

	// Use this for initialization
	void Start () {
		activableGameObjectsInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {

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
