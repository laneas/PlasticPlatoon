using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    GameObject scriptManager;
    public int turnCount;
    public Player playerOne;
    public Player playerTwo;
    public Player currentTurn;

	void Start ()
    {
        scriptManager = gameObject;
        playerOne = (Player)scriptManager.transform.FindChild("PlayerOne").GetComponent("Player");
        playerTwo = (Player)scriptManager.transform.FindChild("PlayerTwo").GetComponent("Player");
        turnCount = 0;
        currentTurn = playerOne;
        playerOne.isTurn = true;
        playerTwo.isTurn = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!currentTurn.checkCommands())
        {
            if (currentTurn == playerOne)
            {
                playerTwo.setTurn();
                currentTurn = playerTwo;
            }
            else
            {
                playerOne.setTurn();
                currentTurn = playerOne;
            }
        }
	}

    
}
