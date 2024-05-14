using Mirror;

public class NetworkManagerClient : NetworkManager
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        ClientSingleton.Instance.CmdPlayerConnected();
    }
}
