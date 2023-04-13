using Mirror;
using System;
using UnityEngine;

public class NetworkListener : NetworkManager
{
    public static new NetworkListener Singleton { get; private set; }

    public event Action OnConfigureHeadlessFrameRate;

    public event Action<string> OnServerChangingScene;

    public event Action<string> OnSceneChangedOfServer;

    public event Action OnSceneChangedOfClient;

    public event Action<string, SceneOperation, bool> OnClientChangingScene;

    public event Action<NetworkConnectionToClient> OnServerConnection;

    public event Action OnClientConnection;

    public event Action OnClientDisConnection;

    public event Action OnNotReadyClient;

    public event Action OnHostStarted;

    public event Action OnHostStopped;

    public event Action OnClientStarted;

    public event Action OnClientStopped;

    public event Action OnServertarted;

    public event Action OnServerStopped;

    public event Action<NetworkConnectionToClient> OnReadyServer;

    public event Action<NetworkConnectionToClient> OnNewPlayer;

    public event Action<NetworkConnectionToClient, TransportError, string> OnErrorOfServer;

    public event Action<TransportError, string> OnErrorOfClient;

    [Header("Other Settings")]
    [SerializeField] private bool _logging = true;



    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Awake()
    {
        base.Awake();

        Singleton = this;
    }

    #region Unity Callbacks

    public override void OnValidate()
    {
        base.OnValidate();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// Networking is NOT initialized when this fires
    /// </summary>
    public override void Start()
    {
        base.Start();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// </summary>
    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    /// <summary>
    /// Runs on both Server and Client
    /// </summary>
    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    #endregion

    #region Start & Stop

    public override void ConfigureHeadlessFrameRate()
    {
        base.ConfigureHeadlessFrameRate();


    }


    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
    }

    #endregion

    #region Scene Management

    public override void ServerChangeScene(string newSceneName)
    {
        base.ServerChangeScene(newSceneName);
    }


    public override void OnServerSceneChanged(string sceneName) { }


    public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling) { }


    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();
    }

    #endregion

    #region Server System Callbacks

    public override void OnServerConnect(NetworkConnectionToClient conn) { }


    public override void OnServerReady(NetworkConnectionToClient conn)
    {
        base.OnServerReady(conn);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);
    }


    public override void OnServerError(NetworkConnectionToClient conn, TransportError transportError, string message) { }

    #endregion

    #region Client System Callbacks

    public override void OnClientConnect()
    {
        base.OnClientConnect();
    }


    public override void OnClientDisconnect() { }


    public override void OnClientNotReady() { }

    public override void OnClientError(TransportError transportError, string message) { }

    #endregion

    #region Start & Stop Callbacks


    public override void OnStartHost() { }


    public override void OnStartServer() { }


    public override void OnStartClient() { }


    public override void OnStopHost() { }


    public override void OnStopServer() { }


    public override void OnStopClient() { }

    #endregion

    #region Logging

    #endregion
}
