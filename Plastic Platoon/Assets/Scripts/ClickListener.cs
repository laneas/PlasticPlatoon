using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Adapted from http://answers.unity3d.com/questions/247810/how-to-get-gameobject-that-is-clicked-by-a-mouse.html

public class ClickListener : MonoBehaviour {

    public GameObject left;
    public GameObject right;

    void Start ()
    {
		
	}

	void FixedUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                left = hit.transform.gameObject;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                right = hit.transform.gameObject;
            }
        }
        else
        {
            left = null;
            right = null;
        }
	}
}
