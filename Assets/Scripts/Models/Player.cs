using AgarMirror.Helpers;
using Newtonsoft.Json;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AgarMirror.Models
{
    [Serializable]
    public class Player
    {
        [JsonRequired]
        public Guid Id { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public Color Color { get; set; }

        public Player ()
        {
            Id = Guid.NewGuid();

            Color = ColorGenerator.GenerateRandomColor();


        }
        [JsonConstructor]
        public Player (Guid id, string name, Color color)
        {
            Id = id;
            Name = name;
            Color = color;
        }
    }
}
