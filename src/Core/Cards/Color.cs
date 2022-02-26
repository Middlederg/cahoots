using System.Collections.Generic;

namespace Cahoots.Core
{
    public record Color : IDisplayableItem
    {
        public string Hex { get; }

        private readonly string name;

        private Color(string hex, string name)
        {
            Hex = hex;
            this.name = name;
        }
        public static Color Red => new Color(nameof(Red), "D82E18");
        public static Color Orange => new Color(nameof(Orange), "E4A102");
        public static Color Green => new Color(nameof(Green), "337558");
        public static Color Blue => new Color(nameof(Blue), "1171D2");
        public static Color Any => new Color(nameof(Any), "fff");

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

        //public string Code => $"[#{Hex}]";

        public override string ToString() => name;
    }
}
