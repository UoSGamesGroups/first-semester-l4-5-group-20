using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	private GameObject Camera;
	public GameObject Play;
	public GameObject Instructions;
	public GameObject Quit;

	void Start () 
	{
		Camera = GameObject.Find ("Main Camera");
		Camera.transform.position = new Vector3 (-55, 0, -10);
		Time.timeScale = 0;
	}

	void Update () 
	{
	
	}

	void OnTrigger2D (Collider2D coll)
	{
		if (coll.gameObject.tag ==  "Play")
		{
			Camera.transform.position = new Vector3 (0, 0, -10);
			Time.timeScale = 1;
		}

		if (coll.gameObject.tag == "Instructions") 
		{
			Camera.transform.position = new Vector3 (-27, 0, -10);
		}
	}
}