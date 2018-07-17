using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivateController : MonoBehaviour {

	public List<GameObject> activableGameObjectsInRange;
	public List<GameObject> objectiveGameObjectsInRange;
	private GameObject activableObject;
	private GameObject objectiveObject;

	// Use this for initialization
	void Start () {
		activableGameObjectsInRange = new List<GameObject>();
		objectiveGameObjectsInRange = new List<GameObject>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") ) {
			activableObject = firstValidActivableGameObject();

			if (activableObject != null) {
				activableObject.GetComponent<DistractionObjectScript>().Deactivate();
			}
			else {
				objectiveObject = firstValidObjectiveGameObject();

				if (objectiveObject != null) {
					objectiveObject.GetComponent<ObjectiveObjectScript>().IncrementCompletion();
				}
			}
		}
	}

	GameObject firstValidActivableGameObject () {
		return activableGameObjectsInRange.Find(
			x => x.GetComponent<DistractionObjectScript>().IsActivable()
		);
	}

	GameObject firstValidObjectiveGameObject () {
		return objectiveGameObjectsInRange.Find(
			x => x.GetComponent<ObjectiveObjectScript>().IsActivable()
		);
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == Constants.Tag.DISTRACTION_OBJECT && !activableGameObjectsInRange.Contains(other.gameObject)) {
			activableGameObjectsInRange.Add(other.gameObject);
		}
		else if (other.tag == Constants.Tag.OBJECTIVE_OBJECT && !objectiveGameObjectsInRange.Contains(other.gameObject)) {
			objectiveGameObjectsInRange.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == Constants.Tag.DISTRACTION_OBJECT) {
			activableGameObjectsInRange.Remove(other.gameObject);
		}
		else if (other.tag == Constants.Tag.OBJECTIVE_OBJECT) {
			objectiveGameObjectsInRange.Remove(other.gameObject);
		}
	}
}
