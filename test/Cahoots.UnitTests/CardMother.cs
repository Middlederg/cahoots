using Cahoots.Core;

namespace Cahoots.UnitTests
{
    public class CardMother
    {
        private static Card Blue(int number) => new Card(number, Color.Blue);
        private static Card Red(int number) => new Card(number, Color.Red);
        private static Card Green(int number) => new Card(number, Color.Green);
        private static Card Orange(int number) => new Card(number, Color.Orange);
        public static Card Blue1 => Blue(1);
        public static Card Blue2 => Blue(2);
        public static Card Blue3 => Blue(3);
        public static Card Blue4 => Blue(4);
        public static Card Blue5 => Blue(5);
        public static Card Blue6 => Blue(6);
        public static Card Blue7 => Blue(7);

        public static Card Red1 => Red(1);
        public static Card Red2 => Red(2);
        public static Card Red3 => Red(3);
        public static Card Red4 => Red(4);
        public static Card Red5 => Red(5);
        public static Card Red6 => Red(6);
        public static Card Red7 => Red(7);

        public static Card Green1 => Green(1);
        public static Card Green2 => Green(2);
        public static Card Green3 => Green(3);
        public static Card Green4 => Green(4);
        public static Card Green5 => Green(5);
        public static Card Green6 => Green(6);
        public static Card Green7 => Green(7);

        public static Card Orange1 => Orange(1);
        public static Card Orange2 => Orange(2);
        public static Card Orange3 => Orange(3);
        public static Card Orange4 => Orange(4);
        public static Card Orange5 => Orange(5);
        public static Card Orange6 => Orange(6);
        public static Card Orange7 => Orange(7);
        
    }
}