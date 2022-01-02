using System.Collections.Generic;

namespace Cahoots.Core
{
    public record Color
    {
        public string Hex { get; }
        private Color(string hex)
        {
            Hex = hex;
        }
        public static Color Red => new Color("D6234A");
        public static Color Orange => new Color("FF6600");
        public static Color Green => new Color("006400");
        public static Color Blue => new Color("2D7AC0");

        public static IEnumerable<Color> Colors
        {
            get
            {
                yield return Red;
                yield return Orange;
                yield return Green;
                yield return Blue;
            }
        }
    }
}
