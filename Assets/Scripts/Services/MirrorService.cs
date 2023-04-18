using AgarMirror;
using AgarMirror.Network.Interfaces;
using AgarMirror.Network.SO;
using AgarMirror.Repositories;
using AgarMirror.Services.Interfaces;
using kcp2k;
using System.Collections.Generic;
using System.Linq;
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

#if UNITY_EDITOR
            networkListener.timeInterpolationGui = true;
#endif


            if (_config.PlayerPrefab != null)
            {
                networkListener.playerPrefab = _config.PlayerPrefab.gameObject;
            }

            RegisterNetworkPrefabs(networkListener);

            Startup.Container.BindInstance<INetworkListener>(networkListener);

        }

        private static void RegisterNetworkPrefabs(NetworkListener networkListener)
        {
            networkListener.spawnPrefabs = new List<GameObject>();

            var repository = Startup.GetRepository<NetworkPrefabsRepository>();

            var prefabs = repository.GetEnumerable().ToArray();

            for (int i = 0; i < prefabs.Length; i++)
            {
                if (prefabs[i].gameObject != networkListener.playerPrefab)
                {
                    networkListener.spawnPrefabs.Add(prefabs[i].gameObject);
                }
                
            }
        }
    }
}
