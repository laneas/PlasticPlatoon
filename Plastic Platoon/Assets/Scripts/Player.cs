using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Character[] units = new Character[30];
    public bool isAI;
    public bool isTurn;
    public int money;

	void Start ()
    {
        isTurn = false;
        isAI = false;
	}

    public void setTurn()
    {
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] != null)
            {
                Character c = (Character)units[i].GetComponent("Character");
                c.halfCommanded = false;
                c.fullCommanded = false;
            }
        }
    }

    public bool checkCommands()
    {
        bool hasCommand = false;
        for (int i = 0; i < units.Length; i++)
        {
            if (units[i] != null)
            {
                if (!units[i].halfCommanded || !units[i].fullCommanded)
                {
                    hasCommand = true;
                }
            }
        }
        return hasCommand;
    }
}
