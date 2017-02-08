using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    public GameObject leftSelection;
    bool leftSelectionChanged;
    public GameObject rightSelection;
    bool rightSelectionChanged;
    ClickListener cl;
    ObjectManager om;
    GameObject[] selectionRange;
    GameObject[] rangeRange;
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

        //Character Selection
        if (leftSelection != null && leftSelection.tag.Equals("Character"))
        {
            if (leftSelectionChanged)
            {
                clearSelections();
                selectionRange = om.showMovement(leftSelection);
                rangeRange = om.showRange(leftSelection);
            }
        }

        //Move
        if (leftSelection != null && rightSelection != null && leftSelection.tag.Equals("Character") && rightSelection.tag.Equals("Tile")) // Later check for if turn, etc
        {
            om.move(leftSelection, rightSelection);
            clearSelections();
            leftSelection = null;
            rightSelection = null;
        }

        //Attack
        if (leftSelection != null && rightSelection != null && leftSelection.tag.Equals("Character") && rightSelection.tag.Equals("Character"))
        {
            Character character = rightSelection.GetComponent<Character>();
            character.takeAttack(leftSelection);
            clearSelections();
            leftSelection = null;
            rightSelection = null;
        }

        //Spawn
        
            
       if (Input.GetKey(KeyCode.B))
       {
            Debug.Log("B");
           if (leftSelection != null && leftSelection.tag.Equals("Spawn"))
           {
                Debug.Log("Base Selected");
                BaseListener playerBase = leftSelection.GetComponent<BaseListener>();
                playerBase.spawnCharacter("blah");
            }
        }
        
    }

    void clearSelections()
    {
        if (selectionRange != null)
        {
            foreach (GameObject plane in selectionRange)
            {
                Destroy(plane);
            }
        }

        if (rangeRange != null)
        {
            foreach (GameObject plane in rangeRange)
            {
                Destroy(plane);
            }
        }
    }
}
