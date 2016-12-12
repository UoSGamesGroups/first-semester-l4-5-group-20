using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Overload : MonoBehaviour 
{
	bool OverloadCD = true;
    public Animator anim;
	private int Cooldown = 45;
	private float Visable = 0.5f;
    int tempTimer;
    public Renderer Render;
    public Slider MainSlider;
	
	void Update ()
	{
        MainSlider.value = tempTimer;

        if ((OverloadCD) && (Input.GetKeyDown (KeyCode.Q)))
		{
            Render.enabled = true;
			StartCoroutine(OverloadActive());
		}
		else if ((!OverloadCD))
		{
            Render.enabled = false;
			StartCoroutine(OverloadRecharge());
		}
	}

	IEnumerator OverloadRecharge ()
	{
        tempTimer = Cooldown;

        for (int i = Cooldown; i > 0; i -= 1)
        {
            tempTimer -= 1;
            yield return new WaitForSeconds(1);
        }

        OverloadCD = true;
    }

	IEnumerator OverloadActive ()
	{
		Vector3 myPos = new Vector3(transform.position.x,transform.position.y,0);
        anim.SetBool("Overload", true);
        yield return new WaitForSeconds (Visable);
        anim.SetBool("Overload", false);
        OverloadCD = false;
	}
}