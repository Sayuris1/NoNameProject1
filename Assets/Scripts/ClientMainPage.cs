using Mirror;
using TMPro;
using UnityEngine;
using UnityFigmaBridge;

public class ClientMainPage : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI NickNameText;
    [SerializeField]
    public TextMeshProUGUI RoomCodeText;

    private NetworkManager _nwManager;
    
    private void Start() 
    {
        _nwManager = NetworkManager.singleton;
    }

    [BindFigmaButtonPress("JoinGameButton")]
    public void JoinGame()
    {
        // Copied from NetworkManagerHUD.cs
        _nwManager.networkAddress = RoomCodeText.text;
        if (Transport.active is PortTransport portTransport)
        {
            if (ushort.TryParse(portTransport.Port.ToString(), out ushort port))
                portTransport.Port = port;
        }

        _nwManager.StartClient();
    }
}
