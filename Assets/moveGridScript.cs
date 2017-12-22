//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

//public class moveGridScript : NetworkBehaviour {

//    public struct moveInput
//    {
//        public bool leftKey;
//        public bool rightKey;
//        public bool upKey;
//        public bool downKey;
//    }

//    public gridGeneratorScript grid;
//    public int playerID;

//    [ServerCallback]
//	void Start () {
//        grid = gridGeneratorScript.instance;
//        grid.players[playerID] = this;

        

        
//        playerID = GetNewPlayerID();

//        playerID = FindObjectOfType<playerCounterScript>().playerCount;
//        FindObjectOfType<playerCounterScript>().playerCount++;

//        switch (playerID)
//        {
//            case 0:
//                grid.playerPositions.Add(new Vector2(1, 1));
//                break;
//            case 1:
//                grid.playerPositions.Add(new Vector2(17, 1));
//                break;
//            case 2:
//                grid.playerPositions.Add(new Vector2(1, 17));
//                break;
//            case 3:
//                grid.playerPositions.Add(new Vector2(17, 17));
//                break;
//            default:
//                break;
//        }

//        Debug.Log(netId.ToString() + " net");
//        Debug.Log(playerID.ToString() + " ID");
//        Debug.Log(playerControllerId.ToString() + " player");
//    }

//    int GetNewPlayerID()
//    {
//        return FindObjectsOfType<moveGridScript>().Length;
//    }
	
//	// Update is called once per frame
//	void Update ()
//    {
//		if(isLocalPlayer) 
//        {
//            InputA();
//        }
//	}

//    public void MovePlayer(Vector3 pos)
//    {
//        gameObject.transform.position = pos;
//    }

//    [Command]
//    void CmdProcessInput(moveInput inputs)
//    {
//        if (inputs.leftKey)
//        {
//            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].breakWall)
//            {
//                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x - 1), (int)(grid.playerPositions[playerID].y)].gridPos;
//            }
//        }
//        else if (inputs.rightKey)
//        {
//            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].breakWall)
//            {
//                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x + 1), (int)(grid.playerPositions[playerID].y)].gridPos;
//            }
//        }
//        else if (inputs.upKey)
//        {
//            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].breakWall)
//            {
//                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y - 1)].gridPos;
//            }
//        }
//        else if (inputs.downKey)
//        {
//            if (!grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].isWall && !grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].breakWall)
//            {
//                grid.playerPositions[playerID] = grid.mapGrid[(int)(grid.playerPositions[playerID].x), (int)(grid.playerPositions[playerID].y + 1)].gridPos;
//            }
//        }
//    }

//    void InputA()
//    {
//        moveInput inputs = new moveInput();

//        inputs.leftKey = Input.GetKeyDown(KeyCode.A);
//        inputs.rightKey = Input.GetKeyDown(KeyCode.D);
//        inputs.upKey = Input.GetKeyDown(KeyCode.W);
//        inputs.downKey = Input.GetKeyDown(KeyCode.S);

//        CmdProcessInput(inputs);
//    }
//}
