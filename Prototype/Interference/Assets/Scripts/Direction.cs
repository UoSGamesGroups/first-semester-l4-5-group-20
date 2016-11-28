using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {

	private float speed = 0.1f;
	Vector2 vector = Vector2.up;
	Vector2 moveVector;
    float Speed = 0.5f;

	void Start ()
    {
		InvokeRepeating("Movement", 0.3f, speed);
	}


	void Update ()
    {
		if (Input.GetKey (KeyCode.D))
        {
            vector = new Vector2(Speed,0);
        }
        else if (Input.GetKey (KeyCode.W))
        {
            vector = new Vector2(0,Speed);
        }
        else if (Input.GetKey (KeyCode.S))
        {
            vector = new Vector2(0,-Speed);
        }
        else if (Input.GetKey (KeyCode.A))
        {
            vector = new Vector2(-Speed,0);
        }

        moveVector = vector.normalized / 2;
	}

	void Movement()
    {
	    transform.Translate(moveVector);
	}
}
