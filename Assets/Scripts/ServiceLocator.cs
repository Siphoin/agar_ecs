using AgarMirror.Exceptions;
using AgarMirror.Services.Interfaces;
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

#if UNITY_EDITOR
            Debug.Log("serivice locator are ready");
#endif
        }

        public void Initialize()
        {
            if (_initialized)
            {
                throw new ServiceLocatorException("serice locator after initialized");
            }

        
            _initialized = true;
        }


    }
}
