using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class ServerSingleton : Singleton<ServerSingleton>
{
    public List<ClientDatas> ConnectedPlayerDatas;

    private void Update() {
        Debug.Log($"ConnectedPlayer : {ConnectedPlayerDatas[0].Name}");
    }
}
