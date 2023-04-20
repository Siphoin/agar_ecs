using AgarMirror.Network.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AgarMirror.Helpers
{
    public class NetworkListenerObserver 
    {
        private INetworkListener _networkListener;

        public NetworkListenerObserver ()
        {
            _networkListener = Startup.Container.Resolve<INetworkListener>();

            
        }

        public void Initialize ()
        {
            _networkListener.OnClientConnection += OnClientConnection;
        }

        private void OnClientConnection()
        {
            _networkListener.OnClientConnection -= OnClientConnection;

            /* TODO: replace to network instancing
             * 
             * 
             * 
            PlayerHelper playerHelper = new GameObject(nameof(PlayerHelper)).AddComponent<PlayerHelper>();

            Object.DontDestroyOnLoad(playerHelper.gameObject);

            */
        }
    }
}
