namespace Cahoots.Core
{
    public record Icon : IDisplayableItem
    {
        private readonly string name;

        private Icon(string name)
        {
            this.name = name;
        }

        public static Icon Even => new Icon(nameof(Even));
        public static Icon Odd => new Icon(nameof(Odd));
        public static Icon Sum => new Icon(nameof(Sum));

        public override string ToString() => name;
    }
}
