using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class moveGridScript : NetworkBehaviour {

    public gridGeneratorScript grid;
    public int playerID;
	void Start () {
        playerID = 0;
        grid = GameObject.FindGameObjectWithTag("gridGen").GetComponent<gridGeneratorScript>();
        grid.players[playerID] = this;
        grid.playerPositions.Add(new Vector2(1, 1));
        Debug.Log(playerControllerId.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		if(isLocalPlayer) 
        {
            InputA();
        }
        
	}

    public void MovePlayer(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    void InputA()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].gridPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].gridPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].gridPos;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].breakWall)
            {
                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].gridPos;
            }
        }
    }

    
}
