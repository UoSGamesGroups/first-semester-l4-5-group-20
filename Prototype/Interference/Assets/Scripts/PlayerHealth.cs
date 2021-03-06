﻿using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	private bool CanBeHit = true;
	private float Timer = 0.5f;
	private GameObject Game_Controller;
	private ProgressBar ProgressScript;
    public Shield ShieldScript;
    public PolygonCollider2D PlayerCollider;
    public Overload OverloadScript;

	void Start ()
	{
		CanBeHit = true;
		Game_Controller = GameObject.Find ("Game_Controller");
		ProgressScript = Game_Controller.GetComponent<ProgressBar> ();
    }

    void Update ()
    {
        if (!ShieldScript.ShieldsUp)
        {
            PlayerCollider.enabled = true;
        }
        else if (ShieldScript.ShieldsUp)
        {
            PlayerCollider.enabled = false;
        }
    }
    
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
            if (!ShieldScript.ShieldsUp)
            {
                if (!OverloadScript.OverloadActivated)
                {
                    if (CanBeHit)
                    {
                        Progress();
                    }
                }
            }
		}
	}

	void Progress ()
	{
		ProgressScript.Progress -= 5;
		CanBeHit = false;
		StartCoroutine (GCD ());
	}

	void FOGOFF ()
	{
		ProgressScript.Progress -= 25;
		transform.position = new Vector3 (0, 0, 0);
	}

	void OnBecameInvisible()
	{
		FOGOFF ();
	}

	IEnumerator GCD ()
	{
		yield return new WaitForSeconds (Timer);
		CanBeHit = true;
	}
}