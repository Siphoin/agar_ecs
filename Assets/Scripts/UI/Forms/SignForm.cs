﻿using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using AgarMirror.UI.Forms.Interfaces;

namespace AgarMirror.UI.Forms
{
    public class SignForm : MonoBehaviour, ISignForm
    {
        [SerializeField] private Button _buttonSubmit;

        [SerializeField] private TMP_InputField _InputFieldNickName;

        public event UnityAction<string> OnSubmit;

        private void Start()
        {
            if (!_InputFieldNickName)
            {
                throw new NullReferenceException("input field nickName not seted");
            }

            if (!_buttonSubmit)
            {
                throw new NullReferenceException("button submit not seted");
            }

            _buttonSubmit.onClick.AddListener(Submit);
        }

        private void Submit()
        {
            string result = _InputFieldNickName.text.Trim();

            if (!string.IsNullOrEmpty(result))
            {
                OnSubmit?.Invoke(result);
            }
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }

        private void RemoveListeners()
        {
            _buttonSubmit.onClick?.RemoveAllListeners();
        }
    }
}