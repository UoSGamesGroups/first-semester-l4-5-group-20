using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Movement : MonoBehaviour {

	public float speed = 5;


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

		//Movement
		var move = new Vector3 (Input.GetAxis("Horizontal"),0);
		transform.position += move*speed*Time.deltaTime;

		}
	}
