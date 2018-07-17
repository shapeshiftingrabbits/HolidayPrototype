using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	GameObject[] distractionObjects;
	GameObject[] objectiveObjects;
	bool allDistractionsHaveFailed = false;
	bool allObjectivesAreComplete = false;

	// Use this for initialization
	void Start () {
		distractionObjects = GameObject.FindGameObjectsWithTag(Constants.Tag.DISTRACTION_OBJECT);
		objectiveObjects = GameObject.FindGameObjectsWithTag(Constants.Tag.OBJECTIVE_OBJECT);
	}

	// Update is called once per frame
	void Update () {
		allDistractionsHaveFailed = System.Array.TrueForAll(distractionObjects, x => x.GetComponent<DistractionObjectScript>().IsFailed());
		allObjectivesAreComplete = System.Array.TrueForAll(objectiveObjects, x => x.GetComponent<ObjectiveObjectScript>().IsComplete());

		if (allDistractionsHaveFailed || allObjectivesAreComplete) {
			RestartLevel();
		}
	}

	void RestartLevel()
	{
		SceneManager.LoadScene (Constants.Scene.MAIN);
	}
}
