using AgarMirror.UI.Forms;
using UnityEngine;
using System;
using Zenject;
using AgarMirror.Network.Interfaces;

namespace AgarMirror.UI.Listeners
{
    public class SignFormListener : MonoBehaviour
    {
        [SerializeField] private SignForm _form;

        private INetworkListener _networkListener;
        private void Start()
        {
            if (!_form)
            {
                throw new NullReferenceException("form sign not seted");
            }

            _networkListener = Startup.Container.Resolve<INetworkListener>();

            _form.OnSubmit += OnSubmit;


        }

        private void OnSubmit(string nickName)
        {
            _networkListener.Connect();
        }
    }
}