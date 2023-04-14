using UnityEngine;

namespace AgarMirror
{
    [CreateAssetMenu]
    public class GameConfig : ScriptableObject
    {
      [SerializeField]  private string _pathNetworkPrefabs;

        public string PathNetworkPrefabs => _pathNetworkPrefabs;
    }
}
