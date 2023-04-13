using Mirror;
using System;

namespace AgarMirror.Network.Interfaces
{
    internal interface INetworkListener
    {
        event Action OnConfigureHeadlessFrameRate;

        event Action<string> OnServerChangingScene;

        event Action<string> OnSceneChangedOfServer;

        event Action OnSceneChangedOfClient;

        event Action<string, SceneOperation, bool> OnClientChangingScene;

        event Action<NetworkConnectionToClient> OnServerConnection;

        event Action OnClientConnection;

        event Action OnClientDisconnection;

        event Action OnNotReadyClient;

        event Action OnHostStarted;

        event Action OnHostStopped;

        event Action OnClientStarted;

        event Action OnClientStopped;

        event Action OnServerStarted;

        event Action OnServerStopped;

        event Action<NetworkConnectionToClient> OnReadyServer;

        event Action<NetworkConnectionToClient> OnNewPlayer;

        event Action<NetworkConnectionToClient, TransportError, string> OnErrorOfServer;

        event Action<TransportError, string> OnErrorOfClient;
    }
}
