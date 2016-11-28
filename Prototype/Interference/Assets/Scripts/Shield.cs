using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
	bool ShieldsUp = false;
	bool ShieldCD = true;
	public GameObject PlasmaShield;
	private GameObject InstantiateShield;
	int Cooldown = 10;
	int Charge = 2;

	void Update () 
	{
		if ((ShieldCD) && (Input.GetKeyDown (KeyCode.E)) && (!ShieldsUp))
		{
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
		Vector3 myPos = new Vector3(transform.position.x,transform.position.y, 0);
		InstantiateShield = (GameObject) Instantiate(PlasmaShield, new Vector3(myPos.x,myPos.y,0), Quaternion.identity);
		InstantiateShield.transform.parent = gameObject.transform;
		yield return new WaitForSeconds (Charge);
		Destroy (InstantiateShield);
		ShieldCD = false;
		ShieldsUp = false;
	}

	IEnumerator ShieldRecharge ()
	{
		yield return new WaitForSeconds (Cooldown);
		ShieldCD = true;
	}
}