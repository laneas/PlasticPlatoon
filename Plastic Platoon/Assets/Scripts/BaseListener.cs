using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseListener : MonoBehaviour {

    GameObject playerBase;
    GameObject[] spawnTiles;
    GameObject soldier;
    bool canSpawn;
    void Start()
    {
        init();
        
    }

    public void spawnCharacter(string type)
    {
        float tileX = spawnTiles[0].transform.position.x;
        float tileY = spawnTiles[0].transform.position.y;
        float tileZ = spawnTiles[0].transform.position.z;

        GameObject spawn = Instantiate(soldier, new Vector3(tileX, tileY, tileZ), Quaternion.identity);
    }

    void init()
    {
        playerBase = gameObject;
        spawnTiles = new GameObject[6];
        for (int i = 0; i < spawnTiles.Length; i++)
        {
            spawnTiles[i] = playerBase.transform.GetChild(i).gameObject;
        }
        soldier = (GameObject)Resources.Load("Soldier");
    }
}
