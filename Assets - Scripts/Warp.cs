﻿using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public Transform warpTarget;

	IEnumerator OnTriggerStay2D(Collider2D other) {

		if (Input.GetKeyDown ("space")) {

			ScreenFader sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<ScreenFader> ();

			yield return StartCoroutine (sf.FadeToBlack ());


			other.gameObject.transform.position = warpTarget.position;
			//Camera.main.transform.position = warpTarget.position;

			yield return StartCoroutine (sf.FadeToClear ());

		}

	}
}
