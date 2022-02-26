using Cahoots.Core;
using Cahoots.Web.Shared;

public static class DisplayableItemsRenderer
{
    public static string Render(this Color color) => $"<span class=\"w-3 mx-0.5 rounded-sm\" style=\"background-color:{color};\" title=\"{color}\"></span>";
    //public static string Render(this Icon icon) => new IconRenderer().re
}
