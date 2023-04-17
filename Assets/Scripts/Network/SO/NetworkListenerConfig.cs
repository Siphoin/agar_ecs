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

        [SerializeField, Min(1)] private int _sendRate = 30;

        [SerializeField, Min(2)] private int _maxPlayersOnServer = 2147483647;

        public string OfflineScene => _offlineScene;
        public string OnlineScene => _onlineScene;

        public string Address => _address;
        public int SendRate => _sendRate;
        public int MaxPlayersOnServer => _maxPlayersOnServer;

        public NetworkBehaviour PlayerPrefab => _playerPrefab;
    }
}