using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchPosition : MonoBehaviour
{
    public Transform crosshair;
    public Slider forceBar;
    public Vector3 worldpos;
    public Vector3 aimpos;
    public string command;
    public int forceAmount = 10;
    public int minForceAmount = 10;
    public int maxForceAmount = 130;

    public void retry_func()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void quit_func()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        command = "aim";
        crosshair = GameObject.Find("Crosshairs").transform;
        Application.targetFrameRate = 60;
        Input.simulateMouseWithTouches = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Locking Aim
        if (Input.GetMouseButtonUp(0) && command == "aim")
        {
            command = "lock";
        }
        if (Input.GetMouseButtonDown(0) && command == "lock")
        {
            command = "shoot";
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            worldpos = hitInfo.point;
        }

        // Aiming
        if (command == "aim")
        {
            if ((worldpos.x > -4 && worldpos.x < 4) && (worldpos.z > -4 && worldpos.z < 4))
            {
                crosshair.transform.position = Vector3.Lerp(crosshair.transform.position, worldpos, 1f);
                aimpos = crosshair.transform.position;
            }
        }

        //Debug.Log("Force =  " + forceAmount);

        // Shooting
        if (command == "shoot")
        {
            RaycastHit hit2;
            var ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray2, out hit2))
            {
                if (hit2.transform.name == "Player")
                {
                    if (Input.GetMouseButton(0))
                    {
                        forceAmount += 2;
                        forceBar.value = forceAmount;

                        if (forceAmount > maxForceAmount)
                        {
                            forceAmount = maxForceAmount;
                        }
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        GetComponent<Rigidbody>().AddForce((aimpos - new Vector3(6, 0, 1)) * forceAmount / 2);
                        forceAmount = minForceAmount;
                    }
                }
            }
        }
    }
}
