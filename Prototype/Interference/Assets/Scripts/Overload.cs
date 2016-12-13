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
    public PolygonCollider2D OverloadCollider;
    private GameObject Game_Controller;
    private ProgressBar ProgressScript;
    public bool OverloadActivated = false;

    void Start ()
    {
        Game_Controller = GameObject.Find("Game_Controller");
        ProgressScript = Game_Controller.GetComponent<ProgressBar>();
        OverloadCollider.enabled = false;
    }

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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            ProgressScript.Progress += 1;
            Destroy(coll.gameObject);
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
        OverloadCollider.enabled = true;
        OverloadActivated = true;
        anim.SetBool("Overload", true);
        yield return new WaitForSeconds (Visable);
        anim.SetBool("Overload", false);
        OverloadActivated = false;
        OverloadCollider.enabled = false;
        OverloadCD = false;
	}
}