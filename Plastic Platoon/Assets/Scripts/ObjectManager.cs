using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

    Material[] materials;
	void Start ()
    {
        materials = new Material[5];
        materials[0] = (Material)Resources.Load("moveInd", typeof(Material));  //Move indication color
        materials[1] = (Material)Resources.Load("runInd", typeof(Material));   //Run indication color
        materials[2] = (Material)Resources.Load("rangeInd", typeof(Material)); //Range indication color
    }

    public GameObject[] showMovement(GameObject character)
    {
        Character stats = character.GetComponent<Character>();
        int range = stats.move;
        int counter = 0;
        GameObject[] planes = new GameObject[(2 * range + 1) * (2 * range + 1)];
        for (int i = -1 * range; i < range + 1; i++)
        {
            for (int j = -1 * range; j < range + 1; j++)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                MeshCollider c = plane.GetComponent<MeshCollider>();
                Destroy(c);
                Vector3 scale = plane.transform.localScale;
                scale.x = .08f;
                scale.z = .08f;
                plane.transform.localScale = scale;
                float xp = -1 * (i - character.transform.position.x);
                float zp = -1 * (j - character.transform.position.z);
                plane.transform.Translate(xp, 1, zp);
                if (Mathf.Abs(plane.transform.position.x - character.transform.position.x) > Mathf.Floor(range / 2) || Mathf.Abs(plane.transform.position.z - character.transform.position.z) > Mathf.Floor(range / 2))
                {
                    plane.GetComponent<Renderer>().material = materials[1];
                }
                else
                {
                    plane.GetComponent<Renderer>().material = materials[0];
                }
                planes[counter] = plane;
                counter++;
            }
        }

        return planes;
    }

    public GameObject[] showRange(GameObject character)
    {
        Character stats = character.GetComponent<Character>();
        int range = stats.range;
        int counter = 0;
        GameObject[] planes = new GameObject[(2 * range + 1) * (2 * range + 1)];
        for (int i = -1 * range; i < range + 1; i++)
        {
            for (int j = -1 * range; j < range + 1; j++)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                MeshCollider c = plane.GetComponent<MeshCollider>();
                Destroy(c);
                Vector3 scale = plane.transform.localScale;
                scale.x = .02f;
                scale.z = .02f;
                plane.transform.localScale = scale;
                float xp = -1 * (i - character.transform.position.x);
                float zp = -1 * (j - character.transform.position.z);
                plane.transform.Translate(xp, 1.01f, zp);
                plane.GetComponent<Renderer>().material = materials[2];
                
                planes[counter] = plane;
                counter++;
            }
        }

        return planes;
    }

    public void move(GameObject character, GameObject tile)
    {
        if (character != null && tile != null)
        {
            float lxPos = character.transform.position.x;
            float lyPos = character.transform.position.y;
            float lzPos = character.transform.position.z;
            float rxPos = tile.transform.position.x;
            float ryPos = tile.transform.position.y;
            float rzPos = tile.transform.position.z;
            float nyPos = 0;
            if (ryPos == lyPos)
            {
                nyPos = 1;
            }
            else
            {
                nyPos = 0;
            }
            Debug.Log("Move (" + lxPos + ", " + lyPos + ", " + lzPos + ") to (" + rxPos + ", " + ryPos + ", " + rzPos + ")");
            character.transform.Translate(rxPos - lxPos, nyPos, rzPos - lzPos);
            Debug.Log("Translate Coordinates: (" + (rxPos - lxPos) + ", " + (nyPos) + ", " + (rzPos - lzPos) + ")");
            character = null;
            tile = null;
        }
    }
}
