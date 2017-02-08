using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    private GameObject map;
    private GameObject flatGrassTile;
    private GameObject playerBase;
    private int mapWidth = 11;
    private int mapHeight = 28;
    void Start()
    {
        init();
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                GameObject temp = Instantiate(flatGrassTile, new Vector3(i, 0, j), Quaternion.identity);
                temp.transform.parent = map.transform;
            }
        }
        GameObject playerOneBase = Instantiate(playerBase, new Vector3((mapWidth / 2) + 1, .2f, 0), Quaternion.identity);
        playerOneBase.transform.Rotate(new Vector3(0, -90, 0));
        GameObject playerTwoBase = Instantiate(playerBase, new Vector3((mapWidth / 2) + 1, .2f, mapHeight - 2), Quaternion.identity);
        playerTwoBase.transform.Rotate(new Vector3(0, -90, 0));
    }

    void init()
    {
        map = GameObject.Find("Map");
        flatGrassTile = (GameObject)Resources.Load("FlatGrassTile");
        playerBase = (GameObject)Resources.Load("Base");
    }
}
