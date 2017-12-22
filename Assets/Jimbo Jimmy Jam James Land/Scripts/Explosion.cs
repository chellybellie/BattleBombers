using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Explosion : NetworkBehaviour
{
    public gridGeneratorScript grid;
    public IntVector2 gridPos;
    void Start()
    {
        grid = gridGeneratorScript.instance;
    }

}
