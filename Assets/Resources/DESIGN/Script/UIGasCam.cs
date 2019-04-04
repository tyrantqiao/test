using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIGasCam : MonoBehaviour
{
    private Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray CamRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(CamRay, out hit))
            {
                Debug.Log(hit.collider.name);
            }
            else
            {
                //Debug.Log("QUIT");
            }
        }
    }
}
