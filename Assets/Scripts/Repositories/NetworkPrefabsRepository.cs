using AgarMirror.Repositories.Interfaces;
using Mirror;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AgarMirror.Repositories
{
    public class NetworkPrefabsRepository : IRepository<NetworkBehaviour>
    {

        private const string FOLBER_PREFABS = "Mirror/NetworkPrefabs";

        private readonly string _dataPath = Application.dataPath;


        private List<NetworkBehaviour> _networkPrefabs;

        public void Initialize()
        {
            string[] prefabFiles = Directory.GetFiles(_dataPath + "/Resources/" + FOLBER_PREFABS, "*.prefab", SearchOption.AllDirectories); // ищем все файлы с расширением .prefab во всех вложенных папках

            foreach (string file in prefabFiles)
            {
                string assetPath = file.Replace("\\", "/").Replace(_dataPath, "Assets");

                NetworkBehaviour prefab = Resources.Load<NetworkBehaviour>(FOLBER_PREFABS + "/" + Path.GetFileNameWithoutExtension(file));

                if (prefab != null)
                {
                    _networkPrefabs.Add(prefab); 
                }

#if UNITY_EDITOR
                Debug.Log($"loaded {_networkPrefabs.Count} network prefabs for Mirror");
#endif
            }
        }

        public IEnumerable<NetworkBehaviour> GetData()
        {
            return _networkPrefabs;
        }

        public NetworkBehaviour GetNetworkObject (string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name argument of object is null");
            }

            return _networkPrefabs.Single(x => x.name == name);
        }
    }
}
