using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	GameObject[] distractionObjects;
	bool allDistractionsHaveFailed = false;

	// Use this for initialization
	void Start () {
		distractionObjects = GameObject.FindGameObjectsWithTag("Activable");
	}

	// Update is called once per frame
	void Update () {
		allDistractionsHaveFailed = System.Array.TrueForAll(distractionObjects, x => x.GetComponent<ActivableScript>().IsFailed());

		if (allDistractionsHaveFailed) {
			RestartLevel();
		}
	}

	void RestartLevel()
	{
		SceneManager.LoadScene ("SampleScene");
	}
}
