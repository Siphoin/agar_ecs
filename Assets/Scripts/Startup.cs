using UnityEngine;

namespace AgarMirror
{
    public static class Startup
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Initialize()
        {

#if UNITY_EDITOR
            Debug.Log($"{nameof(Startup)}: {nameof(Initialize)}()");
#endif
        }
    }
}

