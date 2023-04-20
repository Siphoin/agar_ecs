using AgarMirror.Network.Interfaces;
using AgarMirror.Repositories;
using Mirror;
using System.Collections;
using UnityEngine;

namespace AgarMirror.Helpers
{
    public class PlayerHelper : NetworkBehaviour
    {
        private INetworkListener _listener;

        private PlayerRepository _repository;
        private void Start()
        {
            _listener = Startup.Container.Resolve<INetworkListener>();

            _repository = Startup.GetRepository<PlayerRepository>();

            _listener.OnClientConnection += OnClientConnection;
        }

        private void OnClientConnection()
        {
            InformNewPlayer();
        }
        [ClientRpc]
        private void InformNewPlayer ()
        {
            Debug.Log(nameof(InformNewPlayer));
        }
    }
}