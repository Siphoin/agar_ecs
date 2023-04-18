using AgarMirror.Repositories.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace AgarMirror.Repositories
{
    public class GameSessionRepository : RepositoryBase, IRepository<GameSession>
    {
        private GameSession _gameSession;

        public GameSessionRepository ()
        {
            _gameSession = new GameSession();
        }

        public GameSession GetData()
        {
            return _gameSession;
        }

        public IEnumerable<GameSession> GetEnumerable()
        {
            throw new System.NotImplementedException();
        }

        public void Initialize()
        {
#if UNITY_EDITOR
            Debug.Log($"{nameof(GameSessionRepository)}: {nameof(Initialize)}()");
#endif
        }
    }
}
