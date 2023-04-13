using UnityEngine;

namespace AgarMirror
{
    public static class Startup
    {
        private static ServiceLocator _serviceLocator;


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {
            _serviceLocator = new ServiceLocator();

            _serviceLocator.Initialize();

#if UNITY_EDITOR
            Debug.Log($"{nameof(Startup)}: {nameof(Initialize)}()");
#endif
        }
    }
}

