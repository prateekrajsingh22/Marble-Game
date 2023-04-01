using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail_Select : MonoBehaviour
{
    public GameObject Trail1;
    public GameObject Trail2;
    public GameObject Trail3;
    public GameObject Trail4;

    public void trailColours()
    {
        if (Trail1.GetComponent<TrailRenderer>().enabled == true)
        {
            Trail1.GetComponent<TrailRenderer>().enabled = false;
            Trail2.GetComponent<TrailRenderer>().enabled = true;
            Trail3.GetComponent<TrailRenderer>().enabled = false;
            Trail4.GetComponent<TrailRenderer>().enabled = false;
        }

        else if (Trail2.GetComponent<TrailRenderer>().enabled == true)
        {
            Trail1.GetComponent<TrailRenderer>().enabled = false;
            Trail2.GetComponent<TrailRenderer>().enabled = false;
            Trail3.GetComponent<TrailRenderer>().enabled = true;
            Trail4.GetComponent<TrailRenderer>().enabled = false;
        }

        else if (Trail3.GetComponent<TrailRenderer>().enabled == true)
        {
            Trail1.GetComponent<TrailRenderer>().enabled = false;
            Trail2.GetComponent<TrailRenderer>().enabled = false;
            Trail3.GetComponent<TrailRenderer>().enabled = false;
            Trail4.GetComponent<TrailRenderer>().enabled = true;
        }

        else if (Trail4.GetComponent<TrailRenderer>().enabled == true)
        {
            Trail1.GetComponent<TrailRenderer>().enabled = true;
            Trail2.GetComponent<TrailRenderer>().enabled = false;
            Trail3.GetComponent<TrailRenderer>().enabled = false;
            Trail4.GetComponent<TrailRenderer>().enabled = false;
        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        Trail1 = GameObject.Find("Trail 1");
        Trail2 = GameObject.Find("Trail 2");
        Trail3 = GameObject.Find("Trail 3");
        Trail4 = GameObject.Find("Trail 4");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
