using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
	bool ShieldsUp = false;
	bool ShieldCD = true;
	public GameObject PlasmaShield;

	void Start () 
	{
		PlasmaShield = GameObject.Find ("PlasmaShield");
	}

	void Update () 
	{
		if ((ShieldCD) && (Input.GetKeyDown (KeyCode.Space)) && (!ShieldsUp))
		{
			Debug.Log("Space Was Pressed");
			StartCoroutine(ShieldActive());
		}
		else if ((!ShieldCD) && (!ShieldsUp))
		{
			StartCoroutine(ShieldRecharge());
		}
	}

	IEnumerator ShieldActive ()
	{
		ShieldsUp = true;
		PlasmaShield.renderer.enabled = true;
		yield return new WaitForSeconds (5);
		PlasmaShield.renderer.enabled = false;
		ShieldCD = false;
		ShieldsUp = false;
	}

	IEnumerator ShieldRecharge ()
	{
		yield return new WaitForSeconds (10);
		ShieldCD = true;
	}
}