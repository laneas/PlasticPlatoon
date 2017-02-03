using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void showMovement(GameObject character)
    {
        Character stats = character.GetComponent<Character>();
        int range = stats.move;
        for (int i = -1 * range; i < range + 1; i++)
        {
            for (int j = -1 * range; j < range + 1; j++)
            {
                GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
                Vector3 scale = plane.transform.localScale;
                scale.x = .08f;
                scale.z = .08f;
                plane.transform.localScale = scale;
                float xp =  i - character.transform.position.x;
                float zp =  j - character.transform.position.z;
                plane.transform.Translate(xp, 1, zp);    
            }
        }
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
