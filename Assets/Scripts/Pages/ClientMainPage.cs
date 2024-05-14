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
        string networkAddress = RoomCodeText.text.Remove(RoomCodeText.text.Length - 1);

        _nwManager.networkAddress = networkAddress;
        if (Transport.active is PortTransport portTransport)
        {
            if (ushort.TryParse(portTransport.Port.ToString(), out ushort port))
                portTransport.Port = port;
        }

        _nwManager.StartClient();

        // Set inital datas
        ClientSingleton.Instance.PlayerData.Name = NickNameText.text;
    }
}
