using AgarMirror.Exceptions;
using AgarMirror.Repositories.Interfaces;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AgarMirror.Repositories
{
    public class RepositoriesDb
    {
        private Dictionary<Type, IRepositoryBase> _repositories;

        private bool _initialized;

        public RepositoriesDb()
        {
            _repositories = new Dictionary<Type, IRepositoryBase>();
        }

        public void Initialize()
        {
            if (_initialized)
            {
                throw new ServiceLocatorException("db of repositories after initialized");
            }

            NetworkPrefabsRepository networkPrefabsRepository = new NetworkPrefabsRepository();

            GameSessionRepository gameSessionRepository = new GameSessionRepository();


            _repositories.Add(typeof(NetworkPrefabsRepository), networkPrefabsRepository);

            _repositories.Add(typeof(GameSessionRepository), gameSessionRepository);

            foreach (var service in _repositories)
            {
                service.Value.Initialize();
            }


            _initialized = true;

#if UNITY_EDITOR
            Debug.Log("db of repositories are ready");
#endif
        }

        public T GetRepository<T>() where T : IRepositoryBase
        {
            return (T)_repositories[typeof(T)];
        }
    }
}
