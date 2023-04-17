using AgarMirror.Repositories.Interfaces;
using Mirror;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace AgarMirror.Repositories
{
    public class NetworkPrefabsRepository : RepositoryBase, IRepository<NetworkIdentity>
    {

        private const string FOLBER_PREFABS = "Mirror/NetworkPrefabs";


        private List<NetworkIdentity> _networkPrefabs;

        public NetworkPrefabsRepository ()
        {
            _networkPrefabs = new List<NetworkIdentity>();
        }

        public void Initialize()
        {
            NetworkIdentity[] prefabs = Resources.LoadAll<NetworkIdentity>(FOLBER_PREFABS);

            for (int i = 0; i < prefabs.Length; i++)
            {
                _networkPrefabs.Add(prefabs[i]);
            }

#if UNITY_EDITOR
            Debug.Log($"loaded {_networkPrefabs.Count} network prefabs for Mirror");
#endif
            }

        public IEnumerable<NetworkIdentity> GetData()
        {
            return _networkPrefabs;
        }

        public NetworkIdentity GetNetworkObject (string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name argument of object is null");
            }

            return _networkPrefabs.Single(x => x.name == name);
        }

        private List<string> GetAllFolders(string rootFolder)
        {
            List<string> folders = new List<string>();

            // Проверяем, что указанная папка существует
            if (!Directory.Exists(rootFolder))
            {
                return folders;
            }

            // Добавляем корневую папку в список
            folders.Add(rootFolder);

            // Получаем список всех подпапок в корневой папке
            string[] subFolders = Directory.GetDirectories(rootFolder);

            // Рекурсивно вызываем эту же функцию для каждой найденной папки
            foreach (string subFolder in subFolders)
            {
                List<string> subFoldersList = GetAllFolders(subFolder);
                folders.AddRange(subFoldersList);
            }

            return folders;
        }
    }
}
