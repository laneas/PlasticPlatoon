using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    GameObject leftSelection;
    bool leftSelectionChanged;
    GameObject rightSelection;
    bool rightSelectionChanged;
    ClickListener cl;
    ObjectManager om;
	void Start ()
    {
        GameObject camera = GameObject.Find("Main Camera");
        cl = camera.GetComponent<ClickListener>();
        GameObject manager = GameObject.Find("Script Manager");
        om = manager.GetComponent<ObjectManager>();
        leftSelectionChanged = false;
        rightSelectionChanged = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (cl.left != null)
        {
            if (cl.left != leftSelection) { leftSelectionChanged = true; }
            leftSelection = cl.left;
        }
        else
        {
            leftSelectionChanged = false;
        }

        if (cl.right != null)
        {
            if (cl.right != rightSelection) { rightSelectionChanged = true; }
            rightSelection = cl.right;
        }
        else
        {
            rightSelectionChanged = false;
        }

        if (leftSelection != null && leftSelection.tag.Equals("Character"))
        {
            if (leftSelectionChanged)
            {
                om.showMovement(leftSelection);
            }
        }

        if (leftSelection.tag.Equals("Character") && rightSelection.tag.Equals("Tile")) // Later check for if turn, etc
        {
            om.move(leftSelection, rightSelection);
        }
    }
}
