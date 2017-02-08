using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string type;
    public string rank;
    public int level;
    public int kills;
    private int killsToNextLevel;
    public int hp;
    public int move;
    public int range;
    public int accuracy;
    public int crit;
    public int damageUpper;
    public int damageLower;
    public int cost;
    public bool isSelected;
    public bool halfCommanded;
    public bool fullCommanded;
    private GameObject hitBox;
    private bool inHalfCover;
    private bool inFullCover;

	void Start ()
    {
        killsToNextLevel = 1;
        inHalfCover = false;
        inFullCover = false;
        halfCommanded = true;
        fullCommanded = true;
        isSelected = false;
        level = 0;
        rank = "";
        hitBox = gameObject;
	}

    void checkKills()
    {
        if (kills >= killsToNextLevel)
        {
            levelUp();
            killsToNextLevel *= 2;
            killsToNextLevel += kills;

        }
    }

    public void levelUp()
    {
        level = level + 1;
        hp = hp + 1;
        move = move + 1;
        range = range + 1;
        accuracy = accuracy + 5;
        damageLower = damageLower + 1;
        damageUpper = damageUpper + 2;
        crit = crit + 5;
        if (level == 1) { rank = "I"; }
        else if (level == 2) { rank = "II"; }
        else if (level == 3) { rank = "III"; }
        else { rank = "*"; }
    }

    public bool takeAttack(GameObject enemy)
    {
        bool destroyed = false;
        Character foe = enemy.GetComponent<Character>();

        int coverBonus = 0;
        int foeCrit = foe.crit;
        if (inHalfCover)
        {
            coverBonus = 15;
            foeCrit = foeCrit - 10;
        }
        else if (inFullCover)
        {
            coverBonus = 25;
            foeCrit = foeCrit - 20;
        }
        else
        {
            coverBonus += -30;
            foeCrit += 20;
        }

        int foeAccuracy = foe.accuracy - coverBonus;
        int dam;
        float roll = Random.Range(0, 100);
        if ( roll <= foeAccuracy)
        {
            //hit, roll for damage
            float damRoll = Random.Range(foe.damageLower, foe.damageUpper + 1);
            dam = (int)(Mathf.Round(damRoll));
            //roll for crit
            if (foeCrit > 0 && Random.Range(0, 100) <= foeCrit)
            {
                //crit hit
                dam = dam * 2;
            }
        }
        else
        {
            Debug.Log("Miss!");
            //miss
            dam = 0;
        }
        Debug.Log(" Took " + dam + " damage");
        hp = hp - dam;
        if (hp <= 0)
        {
            Debug.Log(foe.type + " was killed!");
            foe.kills++;
            foe.checkKills();
            destroyed = true;
            die();
        }
        foe.halfCommanded = true;
        foe.fullCommanded = true;
        return destroyed;
    }

    void die()
    {
        Rigidbody rb = hitBox.GetComponent<Rigidbody>();
        hitBox.transform.Rotate(new Vector3(-90, 0, 0));
    }
}
