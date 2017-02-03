using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rig;
    private Vector3 v;
    private Vector3 r;
    private Vector3 z;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        getInput();
        rig.transform.Translate(v);
        rig.transform.Rotate(r);
        rig.transform.Translate(z);
    }

    void getInput()
    {
        //Cardinal Movement
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

        //Camera Rotation
        if (Input.GetKey(KeyCode.Q))
        {
            r = new Vector3(0, 1 * 3, 0);//Vector3.up;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            r = new Vector3(0, -1 * 3, 0);//Vector3.down;
        }
        else
        {
            r = Vector3.zero;
        }

        //Camera Zoom
        if (Input.GetKey(KeyCode.R))
        {
            z = new Vector3(0, -.5f, 0);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            z = new Vector3(0, .5f, 0);
        }
        else
        {
            z = new Vector3(0, Input.GetAxis("Mouse ScrollWheel") * -2, 0);
        }
    }
}