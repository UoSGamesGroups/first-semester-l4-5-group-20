using UnityEngine;
using System.Collections;
 
public class Movement : MonoBehaviour {
 
    float rotationSpeed = 100.0f;
    float thrustForce = 3f;

	public GameObject bullet;
 
 
 
    void Start(){

    }
 
    void FixedUpdate () {
 
        // Rotate the ship if necessary
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*
            rotationSpeed * Time.deltaTime);
 
        // Thrust the ship if necessary
        GetComponent<Rigidbody2D>().
            AddForce(transform.up * thrustForce *
                Input.GetAxis("Vertical"));
		
		// Has a bullet been fired
		if (Input.GetMouseButtonDown (0))
			ShootBullet ();
 
    }

	void ShootBullet(){

		// Spawn a bullet
		Instantiate(bullet,
			new Vector3(transform.position.x,transform.position.y, 0),
			transform.rotation);
	}
 
}