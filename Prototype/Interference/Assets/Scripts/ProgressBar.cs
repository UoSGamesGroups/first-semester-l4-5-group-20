using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

    public int Progress = 25;
    public GameObject Fog1;
    public GameObject Fog2;
    public GameObject Fog3;
    public GameObject Fog4;

    void Start ()
    {
        Fog1.SetActive(true);
        Fog2.SetActive(false);
        Fog3.SetActive(false);
        Fog4.SetActive(false);
    }

    void Update ()
    {
        GetComponent<TextMesh>().text = Progress + ": ";

        if (Progress >= 25 & Progress <= 49)
        {
            Fog1.SetActive(false);
            Fog2.SetActive(true);
        }
        else if (Progress >= 50 & Progress <= 74)
        {
            Fog2.SetActive(false);
            Fog3.SetActive(true);
        }
        else if (Progress >= 75 & Progress <= 99)
        {
            Fog3.SetActive(false);
            Fog4.SetActive(true);
        }
        else if (Progress >= 100)
        {
            Fog4.SetActive(false);
        }
        else if (Progress <= 24)
        {
            Fog1.SetActive(true);
        }
    }
}