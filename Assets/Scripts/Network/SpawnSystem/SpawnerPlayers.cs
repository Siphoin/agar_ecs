using AgarMirror.Network.Interfaces;
using AgarMirror.Network.SpawnSystem.Interfaces;
using AgarMirror.Repositories;
using Mirror;
using System;
using System.Collections;
using UnityEngine;

namespace AgarMirror.Network.SpawnSystem
{
    public class SpawnerPlayers : MonoBehaviour, ISpawner<NetworkIdentity>
    {
        private NetworkIdentity _playerPrefab;

        public event Action<NetworkIdentity> OnSpawn;

        private INetworkListener _networkListener;

        public void Spawn()
        {
            NetworkClient.AddPlayer();
        }

        private void Start()
        {
            _networkListener = Startup.Container.Resolve<INetworkListener>();

            _playerPrefab = Startup.GetRepository<NetworkPrefabsRepository>().GetNetworkObject("Player");

            _networkListener.OnClientConnection += OnClientConnection;

            _networkListener.OnNewPlayer += OnNewPlayer;
        }

        private void OnNewPlayer(NetworkConnectionToClient data)
        {
           if (data.identity.isLocalPlayer)
            {
                OnSpawn?.Invoke(data.identity);

                Debug.Log(nameof(OnNewPlayer));
            }
        }

        private void OnClientConnection()
        {
            Spawn();
        }

        private void OnDestroy()
        {
            if (_networkListener != null)
            {
                _networkListener.OnClientConnection -= OnClientConnection;
            }
        }
    }
}