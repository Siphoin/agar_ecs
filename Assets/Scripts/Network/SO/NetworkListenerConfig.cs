using UnityEditor;
using UnityEngine;

namespace AgarMirror.Network.SO
{
    [CreateAssetMenu]
    public class NetworkListenerConfig : ScriptableObject
    {
        [SerializeField] private SceneAsset _offlineScene;

        [SerializeField] private SceneAsset _onlineScene;

        public SceneAsset OfflineScene => _offlineScene;
        public SceneAsset OnlineScene => _onlineScene;
    }
}