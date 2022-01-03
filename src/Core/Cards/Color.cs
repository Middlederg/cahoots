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
        public static Color Red => new Color("D82E18");
        public static Color Orange => new Color("E4A102");
        public static Color Green => new Color("337558");
        public static Color Blue => new Color("1171D2");

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
