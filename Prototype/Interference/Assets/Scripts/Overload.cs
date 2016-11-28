using UnityEngine;
using System.Collections;

public class Overload : MonoBehaviour 
{
	bool OverloadCD = true;
	public GameObject PlasmaAOE;
	private GameObject InstantiateAOE;
	private int Cooldown = 45;
	private float Visable = 0.5f;
	
	void Update () 
	{
		if ((OverloadCD) && (Input.GetKeyDown (KeyCode.Q)))
		{
			StartCoroutine(OverloadActive());
		}
		else if ((!OverloadCD))
		{
			StartCoroutine(OverloadRecharge());
		}
	}

	IEnumerator OverloadRecharge ()
	{
		yield return new WaitForSeconds (Cooldown);
		OverloadCD = true;
	}

	IEnumerator OverloadActive ()
	{
		Vector3 myPos = new Vector3(transform.position.x,transform.position.y,0);
		InstantiateAOE = (GameObject) Instantiate(PlasmaAOE, new Vector3(myPos.x,myPos.y,0), Quaternion.identity);
		yield return new WaitForSeconds (Visable);
		Destroy (InstantiateAOE);
		OverloadCD = false;
	}
}