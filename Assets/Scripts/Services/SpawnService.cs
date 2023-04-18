using AgarMirror.Network.SpawnSystem;
using AgarMirror.Services.Interfaces;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AgarMirror.Services
{
    public class SpawnService : IService
    {
        public void Initialize()
        {
            Transform root = new GameObject("Spawners").transform;

            Object.DontDestroyOnLoad(root);

            Type[] spawners = new Type[]
            {
                typeof(SpawnerPlayers),
            };

            foreach (Type spawner in spawners)
            {
                AddSpawner(spawner, root);
            }
        }

        private void AddSpawner (Type type, Transform root)
        {
            new GameObject(type.Name).AddComponent(type).transform.SetParent(root);
        }
    }
}
