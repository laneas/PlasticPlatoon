using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rig;
    private Vector3 v;
    private Vector3 r;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        getInput();
        rig.transform.Translate(v);
        rig.transform.Rotate(r);
    }

    void getInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            v = new Vector3(1 * speed, 0 * speed, 1 * speed);//Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            v = new Vector3(-1 * speed, 0 * speed, -1 * speed);//Vector3.right;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            v = new Vector3(1 * speed, 0 * speed, -1 * speed);//Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v = new Vector3(-1 * speed, 0 * speed, 1 * speed);//Vector3.back;
        }
        else
        {
            v = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            r = Vector3.up;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            r = Vector3.down;
        }
        else
        {
            r = Vector3.zero;
        }
    }
}