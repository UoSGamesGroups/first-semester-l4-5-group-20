using UnityEngine;
using System.Collections;

public class MouseFire : MonoBehaviour {
	
	public GameObject bullet;
	public float speed = 10.0f;
    public bool GCD = false;
    public int GLOBALCOOLDOWN = 1;
	
	void Update ()
    {
        if (!GCD)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                GCD = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                GCD = true;
            }
        }

        if (GCD)
        {
            StartCoroutine(GlobalCooldown());
        }
	}

    void Fire()
    {
        if (!GCD)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
            GameObject projectile = (GameObject)Instantiate(bullet, myPos, rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    IEnumerator GlobalCooldown()
    {
        yield return new WaitForSeconds(GLOBALCOOLDOWN);
        GCD = false;
    }
}