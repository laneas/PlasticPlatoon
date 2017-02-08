using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    Canvas canvas;
    GameObject scriptManager;
    SelectionManager selection;

    //For Stat box
    public Text type;
    public Text hp;
    public Text acc;
    public Text crit;
    
	void Start ()
    {
        canvas = GetComponentInParent<Canvas>();
        scriptManager = GameObject.Find("Script Manager");
        selection = scriptManager.GetComponent<SelectionManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (selection.leftSelection != null && selection.leftSelection.tag.Equals("Character"))
        {
            Character c = (Character)selection.leftSelection.GetComponent("Character");
            type.text = c.type+" "+c.rank;
            hp.text = c.hp.ToString();
            acc.text = c.accuracy.ToString() + "%";
            crit.text = c.crit.ToString() + "%";
        }
	}
}
