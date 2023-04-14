using AgarMirror;
using AgarMirror.Network.SO;
using AgarMirror.Services.Interfaces;
using kcp2k;
using UnityEngine;
using Zenject;

namespace Mirror
{
    public class MirrorService : IService
    {
        private NetworkListenerConfig _config;

        public void Initialize()
        {

            _config = Startup.Container.Resolve<NetworkListenerConfig>();

            GameObject networkObject = new GameObject(nameof(NetworkListener));

            KcpTransport kcpTransport = new GameObject(nameof(KcpTransport)).AddComponent<KcpTransport>();

           NetworkListener networkListener = networkObject.AddComponent<NetworkListener>();

           kcpTransport.transform.SetParent(networkObject.transform);

           networkListener.transport = kcpTransport;

           networkListener.dontDestroyOnLoad = true;

           networkListener.autoConnectClientBuild = false;

           networkListener.autoStartServerBuild = false;

           networkListener.autoCreatePlayer = false;

           networkListener.maxConnections = _config.MaxPlayersOnServer;

           networkListener.networkAddress = _config.Address;

           networkListener.offlineScene = _config.OfflineScene;

           networkListener.onlineScene = _config.OnlineScene;
        }
    }
}
