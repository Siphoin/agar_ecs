using AgarMirror.Models;
using AgarMirror.Repositories.Interfaces;
using System.Collections.Generic;
using System;
namespace AgarMirror.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private PlayerContainer _container;

        private Player _localPlayer;

        
        public Player GetData()
        {
            return _localPlayer;
        }

        public IEnumerable<Player> GetEnumerable()
        {
            return _container.GetEnumerable();
        }

        public void Initialize()
        {
           _container = new PlayerContainer();
        }

        public void Clear ()
        {
            _container.Clear();
        }

        public void AddPlayer()
        {
            Player player = new Player();

            AddPlayer(player);
        }

        public void AddPlayer(Player player)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _container.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _container.Remove(player);
        }
    }
}
