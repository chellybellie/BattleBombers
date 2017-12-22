using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkGridTransform : NetworkBehaviour
{
    [SerializeField]
    [HideInInspector]
    private GridTransform _gridTransform;

    [SyncVar]
    private IntVector2 netPosition;

    void Start()
    {
        _gridTransform = (_gridTransform == null ? GetComponent<GridTransform>() : _gridTransform);
    }

    void Update()
    {
        if (hasAuthority) { CmdSendNetPosition(_gridTransform.Position); }
        else { _gridTransform.Position = netPosition; }
    }

    void Reset()
    {
        _gridTransform = GetComponent<GridTransform>();
    }

    [Command]
    void CmdSendNetPosition(IntVector2 v)
    {
        netPosition = v;
    }
}
