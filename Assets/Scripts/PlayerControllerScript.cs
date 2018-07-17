using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour {

	Transform playerTransform;
	private float movementSpeed = 5f;
	private float movementDeadzone = 0.25f;

	// Use this for initialization
	void Start () {
		playerTransform = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		Vector2 movementInput = AxesToVector2 ("Horizontal", "Vertical");

		if (movementInput.magnitude >= movementDeadzone) {
			if (movementInput.magnitude > 1f) {
				movementInput = movementInput / movementInput.magnitude;
			}

			Move (movementInput);
		}
	}

	Vector2 AxesToVector2(string XAxisName, string YAxisName) {
		return new Vector2 (Input.GetAxis (XAxisName), Input.GetAxis (YAxisName));
	}

	void Move(Vector2 movementInput) {
		Vector3 movement = new Vector3 (movementInput.x,  0f, movementInput.y)  * movementSpeed * Time.deltaTime;

		playerTransform.position = playerTransform.position + movement;
	}
}
