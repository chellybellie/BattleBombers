using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gridGeneratorScript : NetworkBehaviour
{
    public GameObject testBlock;
    public float cellSpacing;
    public int length;
    public GameObject wallObj;
    public GameObject breakObj;

    int currentPlayerCounter
    { get { return NetworkManager.singleton.numPlayers; } }

    public static gridGeneratorScript instance;

    public Vector3 pos;
    public int playerCount = 0;

    public struct Node
    {
        public Vector2 gridPos;
        public Vector3 pos;
        public bool isWall;
        public bool breakWall;
        public bool isExploding;
        public float timer;
    }

    public Node[,] mapGrid = new Node[19, 19];
    public Node[] exploding = new Node[5];
    //[SyncVar(hook = "UpdatePlayers")] public Vector2[] playerPositions = new Vector2[4];
    public class SyncListVector2 : SyncListStruct<Vector2>
    {

    }
    public SyncListVector2 playerPositions = new SyncListVector2();

    void Awake()
    {
        if (instance != null) { Destroy(instance); }
        else { instance = this; }
    }

    void Start()
    {
        cellSpacing = testBlock.GetComponent<Renderer>().bounds.size.x;
        length = 19;

        pos = transform.position;
        GridGeneration(length, cellSpacing);

        //playerPositions.Callback += UpdatePlayers;
    }

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if(exploding[i].isExploding && exploding[i].timer > 0)
            {
                exploding[i].timer -= Time.deltaTime;
            }
            else
            {
                exploding[i].isExploding = false;
                exploding[i].timer = 1;
            }
        }
    }

    void GridGeneration(int len, float cSpace)
    {
        for (int y = 0; y < len; y++)
        {
            for (int x = 0; x < len; x++)
            {
                mapGrid[x, y].pos = new Vector3(pos.x + (cSpace * x), pos.y, pos.z - (cSpace * y));
                mapGrid[x, y].gridPos = new Vector2(x, y);
                mapGrid[x, y].isWall = (x == 0 || x == len - 1) || (y == 0 || y == len - 1) || (x % 2 == 0 && y % 2 == 0);
                mapGrid[x, y].breakWall = !(x == 0 || x == len - 1) && !(x == 1 || x == len - 2) && !(y == 0 || y == len - 1) && !(y == 1 || y == len - 2) && (x % 2 == 1 && y % 2 == 1);
                mapGrid[x, y].isExploding = false;
                mapGrid[x, y].timer = 1;
                if (mapGrid[x, y].isWall)
                {
                    GameObject obj = Instantiate(wallObj, mapGrid[x, y].pos, Quaternion.identity);
                    NetworkServer.Spawn(obj);
                }
                if (mapGrid[x, y].breakWall)
                {
                    GameObject brk = Instantiate(breakObj, mapGrid[x, y].pos, Quaternion.identity);
                    NetworkServer.Spawn(brk);
                }
            }
        }
    }
}
