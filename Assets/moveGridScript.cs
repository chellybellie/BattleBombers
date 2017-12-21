using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class moveGridScript : NetworkBehaviour {

    public gridGeneratorScript grid;
    public int playerID;
	void Start () {
        grid = GameObject.FindGameObjectWithTag("gridGen").GetComponent<gridGeneratorScript>();
        grid.playerPositions[playerID].z = playerID;
	}
	
	// Update is called once per frame
	void Update () {
		if(isLocalPlayer) 
        {
            InputA();
        }
	}


    void InputA()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].pos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            
        }
    }

    
}
