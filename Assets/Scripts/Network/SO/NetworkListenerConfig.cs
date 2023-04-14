using Mirror;
using UnityEngine;

namespace AgarMirror.Network.SO
{
    [CreateAssetMenu]
    public class NetworkListenerConfig : ScriptableObject
    {
        [Scene]

        [SerializeField] private string _offlineScene;

        [Scene]

        [SerializeField] private string _onlineScene;

        [SerializeField] private NetworkBehaviour _playerPrefab;

        [SerializeField] private string _address = "localhost";

        [SerializeField] private uint _sendRate = 30;

        [SerializeField] private uint _maxPlayersOnServer = 2147483647;

        public string OfflineScene => _offlineScene;
        public string OnlineScene => _onlineScene;

        public string Address => _address;
        public int SendRate => (int)_sendRate;
        public int MaxPlayersOnServer => (int)_maxPlayersOnServer;

        public NetworkBehaviour PlayerPrefab => _playerPrefab;
    }
}