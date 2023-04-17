using System.ComponentModel;
using UnityEngine;
using Zenject;
using System;
using Object = UnityEngine.Object;
using AgarMirror.Network.SO;

namespace AgarMirror
{
    public static class Startup
    {
        private const string PATH_CONFIGS = "config/SO/";

        private const string NAME_FILE_GAME_CONFIG = "GameConfig";

        private const string NAME_FILE_NETWORK_LISTENER_CONFIG = "NetwoekListenerConfig";

        private static ServiceLocator _serviceLocator;

        private static GameConfig _gameConfig;

        private static NetworkListenerConfig _networkListenerConfig;

        public static DiContainer Container => ProjectContext.Container;

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

            _serviceLocator.Initialize();

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
    }

}

