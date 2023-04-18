using AgarMirror.UI.Forms;
using UnityEngine;
using System;
using Zenject;
using AgarMirror.Network.Interfaces;
using AgarMirror.Repositories;

namespace AgarMirror.UI.Listeners
{
    public class SignFormListener : MonoBehaviour
    {
        [SerializeField] private SignForm _form;

        private INetworkListener _networkListener;

        private GameSessionRepository _sessionRepository;
        private void Start()
        {
            if (!_form)
            {
                throw new NullReferenceException("form sign not seted");
            }

            _networkListener = Startup.Container.Resolve<INetworkListener>();

            _sessionRepository = Startup.GetRepository<GameSessionRepository>();

            _form.OnSubmit += OnSubmit;


        }

        private void OnSubmit(string nickName)
        {
            _sessionRepository.GetData().SetNickName(nickName);

            _networkListener.Connect();
        }
    }
}