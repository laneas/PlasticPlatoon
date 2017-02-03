using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    private GameObject map;
    private GameObject flatGrassTile;
    void Start()
    {
        init();
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                GameObject temp = Instantiate(flatGrassTile, new Vector3(i, 0, j), Quaternion.identity);
                temp.transform.parent = map.transform;
            }
        }
    }

    void init()
    {
        map = GameObject.Find("Map");
        flatGrassTile = (GameObject)Resources.Load("FlatGrassTile");
    }
}
