using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public int Level = 1;
    public GameObject BG1;
    public GameObject BG2;
    public GameObject BG3;
    public GameObject BG4;
    private GameObject Game_Controller;
    private ProgressBar ProgressScript;

    void Start ()
    {
        Level = 1;
        Game_Controller = GameObject.Find("Game_Controller");
        ProgressScript = Game_Controller.GetComponent<ProgressBar>();
    }

	void Update ()
    {
        if (ProgressScript.Progress >= 100)
        {
            Level += 1;
        }

        if (Level == 1)
        {
            BG1.transform.position = new Vector3(0, 0, 10);
        }
        else if (Level == 2)
        {
            BG2.transform.position = new Vector3(0, 0, 10);
            BG1.transform.position = new Vector3(0, -12, 10);
        }
        else if (Level == 3)
        {
            BG3.transform.position = new Vector3(0, 0, 10);
            BG2.transform.position = new Vector3(0, -12, 10);
        }
        else if (Level == 4)
        {
            BG4.transform.position = new Vector3(0, 0, 10);
            BG3.transform.position = new Vector3(0, -12, 10);
        }
    }
}
