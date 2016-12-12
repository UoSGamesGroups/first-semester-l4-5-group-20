using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shield : MonoBehaviour 
{
	bool ShieldsUp = false;
	bool ShieldCD = true;
	public Animator anim;
	int Cooldown = 10;
    int tempTimer;
    int Charge = 2;
    public Renderer Render;
    public Slider MainSlider;

    void Update () 
	{
        MainSlider.value = tempTimer;

		if ((ShieldCD) && (Input.GetKeyDown (KeyCode.E)) && (!ShieldsUp))
		{
            Render.enabled = true;
            StartCoroutine(ShieldActive());
		}
		else if ((!ShieldCD) && (!ShieldsUp))
		{
            Render.enabled = false;
            StartCoroutine(ShieldRecharge());
		}
	}

	IEnumerator ShieldActive ()
	{
		ShieldsUp = true;
		Vector3 myPos = new Vector3(transform.position.x,transform.position.y, 0);
        anim.SetBool("Shield", true);
		yield return new WaitForSeconds (Charge);
        anim.SetBool("Shield", false);
		ShieldCD = false;
		ShieldsUp = false;
	}

	IEnumerator ShieldRecharge ()
	{
        tempTimer = Cooldown;

        for (int i = Cooldown; i > 0; i -= 1)
        {
            tempTimer -= 1;
            yield return new WaitForSeconds(1);
        }

		ShieldCD = true;
	}
}