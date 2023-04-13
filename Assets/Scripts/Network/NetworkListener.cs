using AgarMirror.Network.Interfaces;
using Mirror;
using System;
using UnityEngine;

public class NetworkListener : NetworkManager, INetworkListener
{
    public static new NetworkListener Singleton { get; private set; }

    public event Action OnConfigureHeadlessFrameRate;

    public event Action<string> OnServerChangingScene;

    public event Action<string> OnSceneChangedOfServer;

    public event Action OnSceneChangedOfClient;

    public event Action<string, SceneOperation, bool> OnClientChangingScene;

    public event Action<NetworkConnectionToClient> OnServerConnection;

    public event Action OnClientConnection;

    public event Action OnClientDisconnection;

    public event Action<NetworkConnectionToClient> OnServerDisconnection;

    public event Action OnNotReadyClient;

    public event Action OnHostStarted;

    public event Action OnHostStopped;

    public event Action OnClientStarted;

    public event Action OnClientStopped;

    public event Action OnServerStarted;

    public event Action OnServerStopped;

    public event Action<NetworkConnectionToClient> OnReadyServer;

    public event Action<NetworkConnectionToClient> OnNewPlayer;

    public event Action<NetworkConnectionToClient, TransportError, string> OnErrorOfServer;

    public event Action<TransportError, string> OnErrorOfClient;



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

        OnConfigureHeadlessFrameRate?.Invoke();

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

        OnServerChangingScene?.Invoke(newSceneName);
    }


    public override void OnServerSceneChanged(string sceneName)
    {
        OnServerChangingScene?.Invoke(sceneName);
    }


    public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
    {
        OnClientChangingScene?.Invoke(newSceneName, sceneOperation, customHandling);
    }


    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();
    }

    #endregion

    #region Server System Callbacks

    public override void OnServerConnect(NetworkConnectionToClient conn)
    {
        OnServerConnection?.Invoke(conn);
    }


    public override void OnServerReady(NetworkConnectionToClient conn)
    {
        base.OnServerReady(conn);

        OnReadyServer?.Invoke(conn);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        OnNewPlayer?.Invoke(conn);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);

        OnServerDisconnection?.Invoke(conn);
        
    }


    public override void OnServerError(NetworkConnectionToClient conn, TransportError transportError, string message)
    {
        Debug.LogError($"Mirror Server Error: TransportError: {transportError} Message: {message}");

        OnErrorOfServer?.Invoke(conn, transportError, message);
    }

    #endregion

    #region Client System Callbacks

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        OnClientConnection?.Invoke();
    }


    public override void OnClientDisconnect()
    {
        OnClientDisconnection?.Invoke();
    }


    public override void OnClientNotReady()
    {
        OnNotReadyClient?.Invoke();
    }

    public override void OnClientError(TransportError transportError, string message)
    {
        Debug.LogError($"Mirror Client Error: TransportError: {transportError} Message: {message}");

        OnErrorOfClient?.Invoke(transportError, message);
    }

    #endregion

    #region Start & Stop Callbacks


    public override void OnStartHost()
    {
        OnHostStarted?.Invoke();
    }


    public override void OnStartServer()
    {
        OnServerStarted?.Invoke();
    }


    public override void OnStartClient()
    {
        OnClientStarted?.Invoke();
    }


    public override void OnStopHost()
    {
        OnHostStopped?.Invoke();
    }


    public override void OnStopServer()
    {
        OnServerStopped?.Invoke();
    }


    public override void OnStopClient() 
    {
        OnClientStopped?.Invoke();
    }

    #endregion
}
