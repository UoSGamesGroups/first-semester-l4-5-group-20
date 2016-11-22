using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

	private float speed = 0.1f;
	Vector2 vector = Vector2.up;
	Vector2 moveVector;

	void Start () {
		InvokeRepeating("Movement", 0.3f, speed);

	}

	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			vector = Vector2.right;
		} else if (Input.GetKey (KeyCode.W)) {
			vector = Vector2.up;
		} else if (Input.GetKey (KeyCode.S)) {
			vector = -Vector2.up;
		} else if (Input.GetKey (KeyCode.A)) {
			vector = -Vector2.right;
		}
		moveVector = vector / 3f;

	}

	void Movement() {
		transform.Translate(moveVector);
	}
}
