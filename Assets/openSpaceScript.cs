using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openSpaceScript : MonoBehaviour {

    public bool walkable;
	void Start () {
        walkable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "block")
        {
            walkable = false;
        }
        else
        {
            walkable = true;
        }
    }
}
