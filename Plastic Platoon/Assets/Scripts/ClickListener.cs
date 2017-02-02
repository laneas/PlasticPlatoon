using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Adapted from http://answers.unity3d.com/questions/247810/how-to-get-gameobject-that-is-clicked-by-a-mouse.html

public class ClickListener : MonoBehaviour {

    public GameObject leftSelected;
    public GameObject rightSelected;

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
                leftSelected = hit.transform.gameObject;
                if (leftSelected.tag.Equals("Tile"))
                {
                    leftSelected = null;
                }
                Debug.Log("Left Selected: "+hit.transform.gameObject.name);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                rightSelected = hit.transform.gameObject;
                if (!rightSelected.tag.Equals("Tile"))
                {
                    rightSelected = null;
                }
                Debug.Log("Right Selected: "+hit.transform.gameObject.tag);
            }
        }
	}
}
