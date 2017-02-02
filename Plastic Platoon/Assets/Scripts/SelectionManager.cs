using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    GameObject leftSelected;
    GameObject rightSelected;
    ClickListener cl;
	void Start ()
    {
        GameObject camera = GameObject.Find("Main Camera");
        cl = camera.GetComponent<ClickListener>();
        leftSelected = cl.leftSelected;
        rightSelected = cl.rightSelected;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        leftSelected = cl.leftSelected;
        rightSelected = cl.rightSelected;
        move();
    }

    void move()
    {
        if (leftSelected != null && rightSelected != null)
        {
            float lxPos = leftSelected.transform.position.x;
            float lyPos = leftSelected.transform.position.y;
            float lzPos = leftSelected.transform.position.z;
            float rxPos = rightSelected.transform.position.x;
            float ryPos = rightSelected.transform.position.y;
            float rzPos = rightSelected.transform.position.z;
            float nyPos = 0;
            if (ryPos == lyPos)
            {
                nyPos = 1;
            }
            else
            {
                nyPos = 0;
            }
            Debug.Log("Move (" + lxPos + ", " + lyPos + ", " + lzPos + ") to (" + rxPos + ", " + ryPos + ", " + rzPos + ")");
            leftSelected.transform.Translate(rxPos - lxPos, nyPos, rzPos - lzPos);
            Debug.Log("Translate Coordinates: (" + (rxPos - lxPos) + ", " + (nyPos) + ", " + (rzPos - lzPos) + ")");
            cl.leftSelected = null;
            cl.rightSelected = null;
        }
    }
}
