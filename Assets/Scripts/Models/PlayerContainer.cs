using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AgarMirror.Models
{
    [Serializable]
    internal class PlayerContainer : ICollection<Player>
    {
        [JsonRequired]

        private List<Player> _players;

        [JsonIgnore]

        public int Count => _players.Count;

        [JsonIgnore]
        public bool IsReadOnly => false;

        public PlayerContainer()
        {
            _players = new List<Player>();
        }


        [JsonConstructor]
        public PlayerContainer (List<Player> players)
        {
            if (players is null)
            {
                throw new ArgumentNullException("player collection is null");
            }
        }



        public void Add(Player item)
        {
            _players.Add(item);
        }

        public void Clear()
        {
            _players.Clear();
        }

        public bool Contains(Player item)
        {
            return _players.Contains(item);
        }

        public void CopyTo(Player[] array, int arrayIndex)
        {
            _players.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return _players.GetEnumerator();
        }

        public bool Remove(Player item)
        {
           return _players.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Player> GetEnumerable()
        {
            return _players;
        }
    }
}
