using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string type;
    public int level;
    public int kills;
    public int hp;
    public int move;
    public int range;
    public int accuracy;
    public int damageUpper;
    public int damageLower;
    public int cost;
    private GameObject model;

	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void levelUp()
    {
        level = level + 1;
        hp = hp + 1;
        move = move + 1;
        range = range + 1;
        accuracy = accuracy + 5;
        damageLower = damageLower + 1;
        damageUpper = damageUpper + 2;
    }
}
