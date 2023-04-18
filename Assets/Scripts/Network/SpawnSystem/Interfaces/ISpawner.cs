using System;

namespace AgarMirror.Network.SpawnSystem.Interfaces
{
    public interface ISpawner<SpawnObject>
    {
        event Action<SpawnObject> OnSpawn;

        void Spawn();
    }
}
