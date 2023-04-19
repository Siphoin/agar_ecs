using UnityEngine;
using Zenject;
using System;
using Object = UnityEngine.Object;
using AgarMirror.Network.SO;
using AgarMirror.Repositories;
using AgarMirror.Services.Interfaces;
using AgarMirror.Repositories.Interfaces;
using AgarMirror.InputSystem;
using AgarMirror.InputSystem.Interfaces;

namespace AgarMirror
{
    public static class Startup
    {
        private const string PATH_CONFIGS = "config/SO/";

        private const string NAME_FILE_GAME_CONFIG = "GameConfig";

        private const string NAME_FILE_NETWORK_LISTENER_CONFIG = "NetwoekListenerConfig";

        private static ServiceLocator _serviceLocator;

        private static RepositoriesDb _repositories;

        private static GameConfig _gameConfig;

        private static NetworkListenerConfig _networkListenerConfig;

        private static InputListener _inputListener;

        public static DiContainer Container => ProjectContext.Container;

        public static IInputListener Input => _inputListener;

        private static ProjectContext ProjectContext => ProjectContext.Instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            Object.DontDestroyOnLoad(ProjectContext);
            
            _gameConfig = LoadGameConfig();

            _networkListenerConfig = LoadNetworkListenerConfig();

            

            BindGameConfig(_gameConfig);

            BindNetworkListenerConfig(_networkListenerConfig);



            _serviceLocator = new ServiceLocator();

            _repositories = new RepositoriesDb();

            _repositories.Initialize();

            _serviceLocator.Initialize();

            _inputListener = new InputListener();



#if UNITY_EDITOR
            Debug.Log($"{nameof(Startup)}: {nameof(Initialize)}()");
#endif
        }

        private static GameConfig LoadGameConfig()
        {
           GameConfig gameConfig = Resources.Load<GameConfig>($"{PATH_CONFIGS}{NAME_FILE_GAME_CONFIG}");


            if (gameConfig != null)
            {
#if UNITY_EDITOR
                Debug.Log("game config loaded");
#endif
            }

            else
            {
                throw new NullReferenceException("game config not found");
            }

           return gameConfig;
        }

        private static void BindGameConfig(GameConfig gameConfig) 
            => Container.BindInstance(gameConfig);

        private static NetworkListenerConfig LoadNetworkListenerConfig()
        {
            NetworkListenerConfig networkListenerConfig = Resources.Load<NetworkListenerConfig>($"{PATH_CONFIGS}{NAME_FILE_NETWORK_LISTENER_CONFIG}");


            if (networkListenerConfig != null)
            {
#if UNITY_EDITOR
                Debug.Log("network listener config loaded");
#endif
            }

            else
            {
                throw new NullReferenceException("game config not found");
            }

            return networkListenerConfig;
        }

        private static void BindNetworkListenerConfig(NetworkListenerConfig networkListenerConfig)
            => Container.BindInstance(networkListenerConfig);

        public static T GetRepository<T>() where T : IRepositoryBase
        {
            return _repositories.GetRepository<T>();
        }

        public static T GetService<T>() where T : IService
        {
            return _serviceLocator.GetService<T>();
        }
    }

}

