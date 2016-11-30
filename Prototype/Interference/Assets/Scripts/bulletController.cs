using UnityEngine;
using System.Collections;

public class bulletController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Progress();
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }
    
    void Progress()
    {
        GameObject Game_Controller = GameObject.Find("Game_Controller");
        ProgressBar ProgressScript = Game_Controller.GetComponent<ProgressBar>();
        ProgressScript.Progress += 1;
    }

    void OnBecameInvisible()
	{
		Destroy (gameObject);
	}
}