using UnityEngine;
using Random = UnityEngine.Random;

namespace AgarMirror.Helpers
{
    public static class ColorGenerator
    {

        public static Color GenerateRandomColor()
        {
            Color randomColor = Random.ColorHSV(0f, 0.5f, 1, 1, 0.5f, 1f);

            return randomColor;
        }
    }
}
