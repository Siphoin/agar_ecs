using AgarMirror.Services.Interfaces;
using kcp2k;
using UnityEngine;

namespace Mirror
{
    public class MirrorService : IService
    {


        public void Initialize()
        {

            GameObject networkObject = new GameObject(nameof(NetworkListener));

            KcpTransport kcpTransport = new GameObject(nameof(KcpTransport)).AddComponent<KcpTransport>();

           NetworkListener networkListener = networkObject.AddComponent<NetworkListener>();

           kcpTransport.transform.SetParent(networkObject.transform);

           networkListener.transport = kcpTransport;

           networkListener.dontDestroyOnLoad = true;
        }
    }
}
