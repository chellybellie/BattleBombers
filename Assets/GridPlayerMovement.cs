using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GridPlayerMovement : NetworkBehaviour
{
    GridTransform gridTransform;

    public struct moveInput
    {
        public bool leftKey;
        public bool rightKey;
        public bool upKey;
        public bool downKey;
    }

    void Start()
    {
        gridTransform = GetComponent<GridTransform>();
    }

    void Update()
    {
        if (!isLocalPlayer) { return; }

        InputA();
    }

    void CmdProcessInput(moveInput inputs)
    {
        if (inputs.leftKey)
        {
            if (!gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x - 1), (int)(gridTransform.Position.y)].isWall && !gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x - 1), (int)(gridTransform.Position.y)].breakWall)
            {
                gridTransform.Position = gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x - 1), (int)(gridTransform.Position.y)].gridPos;
            }
        }
        else if (inputs.rightKey)
        {
            if (!gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x + 1), (int)(gridTransform.Position.y)].isWall && !gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x + 1), (int)(gridTransform.Position.y)].breakWall)
            {
                gridTransform.Position = gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x + 1), (int)(gridTransform.Position.y)].gridPos;
            }
        }
        else if (inputs.upKey)
        {
            if (!gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y - 1)].isWall && !gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y - 1)].breakWall)
            {
                gridTransform.Position = gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y - 1)].gridPos;
            }
        }
        else if (inputs.downKey)
        {
            if (!gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y + 1)].isWall && !gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y + 1)].breakWall)
            {
                gridTransform.Position = gridGeneratorScript.instance.mapGrid[(int)(gridTransform.Position.x), (int)(gridTransform.Position.y + 1)].gridPos;
            }
        }
    }

    void InputA()
    {
        moveInput inputs = new moveInput();

        inputs.leftKey = Input.GetKeyDown(KeyCode.A);
        inputs.rightKey = Input.GetKeyDown(KeyCode.D);
        inputs.upKey = Input.GetKeyDown(KeyCode.W);
        inputs.downKey = Input.GetKeyDown(KeyCode.S);

        CmdProcessInput(inputs);
    }
}
