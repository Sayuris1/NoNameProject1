using Mirror;

public class ClientSingleton : Singleton<ClientSingleton>
{
    public ClientDatas PlayerData;

    protected override void Awake()
    {
        base.Awake();

        PlayerData = new();
    }

    [Command]
    public void CmdPlayerConnected()
    {
        ServerSingleton.Instance.ConnectedPlayerDatas.Add(Instance.PlayerData);
    }
}
