using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour {

    public Vector3 v;
    public CharacterController c;
	// Use this for initialization
	void Start () {
        
        v = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            v.x -= 0.05f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            v.x += 0.05f;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            v.z += 0.05f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            v.z -= 0.05f;
        }

        c.Move(v);

        v *= 0.7f;
    }
}
