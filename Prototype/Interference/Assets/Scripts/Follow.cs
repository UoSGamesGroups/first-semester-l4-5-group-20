using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    bool alive = false;
    public float EnemySpeed = 1f;
	public Transform Target;	
	public float angle;

    void Start() 
    {
    	Target = GameObject.FindWithTag("Player").transform;
		alive = true;
    }
    
    void Update() 
    {
        if (alive == true) 
        {
            // build an angle between Enemy and the player.

            // get a vector that points between this zombie and the target
            Vector2 diff = Target.position - transform.position;
            // find the angle of that vector
            angle = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90f;
            // build a quaternion to represent that rotation
			Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            // and apply it over time with a spherical linear interpolation
			transform.rotation = q;//Quaternion.Slerp(transform.rotation, q, 0.5f);
        }

		if (Vector3.Distance(transform.position, Target.position) > 0) 
		{
			transform.position += transform.up * (EnemySpeed * Time.deltaTime);
		}
    }

    /*
    void OnBecameVisible() 
    {
    	alive = true;
    }

    void OnBecameInvisible() 
    {
		if (alive == true) 
		{
			Destroy(gameObject);
		}
	}*/
}
 