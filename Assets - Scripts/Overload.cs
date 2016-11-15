using UnityEngine;
using System.Collections;

public class Overload : MonoBehaviour 
{
	bool OverloadCD = true;
	public GameObject PlasmaAOE;
	
	void Start () 
	{
		PlasmaAOE = GameObject.Find ("PlasmaAOE");
	}
	
	void Update () 
	{
		if ((OverloadCD) && (Input.GetKeyDown (KeyCode.Q)))
		{
			Debug.Log("Q Was Pressed");
			OverloadActive();
		}
		else if ((!OverloadCD))
		{
			PlasmaAOE.renderer.enabled = false;
			StartCoroutine(OverloadRecharge());
		}
	}

	IEnumerator OverloadRecharge ()
	{
		yield return new WaitForSeconds (45);
		OverloadCD = true;
	}

	void OverloadActive ()
	{
		PlasmaAOE.renderer.enabled = true;
		OverloadCD = false;
	}
}