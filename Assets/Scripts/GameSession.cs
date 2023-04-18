using System;
using UnityEngine;

namespace AgarMirror
{
    [Serializable]
    public class GameSession
    {
        private string _nickName;

        public string NickName => _nickName;

        public void SetNickName (string nickName)
        {
            nickName = nickName.Trim();

            if (string.IsNullOrEmpty(nickName))
            {
                throw new ArgumentNullException("nickName is empty");
            }

            _nickName = nickName;

#if UNITY_EDITOR
            Debug.Log($"nickName of current game session seted as {_nickName}");
#endif
        }
    }
}
