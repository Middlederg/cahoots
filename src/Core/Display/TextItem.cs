namespace Cahoots.Core
{
    public class TextItem : IDisplayableItem
    {
        public TextItem(string text)
        {
            Text = text;
        }

        public string Text { get; }

        public static TextItem Separator => new("-");
        public static TextItem Or => new("/");
        public static TextItem Equal => new("=");
        public static TextItem Twice => new("x2");
        public static TextItem FourTimes => new("x4");
        public static TextItem Times(int times) => new($"x{times}");
        public static TextItem GreaterThan => new(">");
        public static TextItem LowerThan => new("<");
    }
}
