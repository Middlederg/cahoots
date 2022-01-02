using System;

namespace Cahoots.Core
{
    public record Card
    {
        private readonly Guid id;
        public int Number { get; }
        public Color Color { get; }

        public Card(int number, Color color)
        {
            id = Guid.NewGuid();
            Number = number;
            Color = color;
        }
        public bool IsEven => Number % 2 == 0;
        public EvenOddStatus Status => IsEven ? EvenOddStatus.Even : EvenOddStatus.Odd;

        public override string ToString() => Number.ToString();
    }
}
