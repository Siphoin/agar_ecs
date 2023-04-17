using AgarMirror.Exceptions;
using AgarMirror.Services.Interfaces;
using Mirror;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AgarMirror
{
    public class ServiceLocator
    {
        private Dictionary<Type, IService> _services;

        private bool _initialized;

        public ServiceLocator()
        {
            _initialized = false;

            _services = new Dictionary<Type, IService>();
        }

        public void Initialize()
        {
            if (_initialized)
            {
                throw new ServiceLocatorException("serice locator after initialized");
            }

            MirrorService mirrorService = new MirrorService();



            _services.Add(typeof(MirrorService), mirrorService);

            foreach (var service in _services)
            {
                service.Value.Initialize();
            }


            _initialized = true;

#if UNITY_EDITOR
            Debug.Log("serivice locator are ready");
#endif
        }

        public T GetService<T>() where T : IService
        {
            return (T)_services[typeof(T)];
        }


    }
}
