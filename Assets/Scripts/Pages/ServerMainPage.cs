using Mirror;
using UnityEngine;
using UnityFigmaBridge;

public class ServerMainPage : MonoBehaviour
{
    private NetworkManager _nwManager;
    
    private void Start() 
    {
#if UNITY_WEBGL
        Debug.LogError("Cant be a server in WebGL build");
        return;
#endif
        _nwManager = NetworkManager.singleton;
    }

    [BindFigmaButtonPress("StartServerButton")]
    public void StartServer()
    {
        // Copied from NetworkManagerHUD.cs
        if (NetworkServer.active)
        {
            Debug.LogError("NetworkServer is already active");
            return;
        }

        //_nwManager.networkAddress = _nwManager.networkAddress;
        if (Transport.active is PortTransport portTransport)
        {
            if (ushort.TryParse(portTransport.Port.ToString(), out ushort port))
                portTransport.Port = port;
        }

        _nwManager.StartServer();
    }
}

