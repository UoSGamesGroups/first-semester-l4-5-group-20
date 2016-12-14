using UnityEngine;
using System.Collections;

public class ChangeDirection : MonoBehaviour {

	public Sprite BrainU,BrainR,BrainD,BrainL;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W))
			this.GetComponent<SpriteRenderer> ().sprite = BrainU;
		if (Input.GetKey (KeyCode.S))
			this.GetComponent<SpriteRenderer> ().sprite = BrainD;
		if (Input.GetKey (KeyCode.D))
			this.GetComponent<SpriteRenderer> ().sprite = BrainR;
		if (Input.GetKey (KeyCode.A))
			this.GetComponent<SpriteRenderer> ().sprite = BrainL;
	}
}
