using System.Collections.Generic;

namespace Cahoots.Core
{
    public interface IMission
    {
        bool CanBeCompleted(CardSet cardSet);
        string Description();
        IEnumerable<IDisplayableItem> Display();
    }
}
