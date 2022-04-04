using Cahoots.Core;
using Cahoots.Web.Shared.Icons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Cahoots.Web.Shared
{
    public class DisplayItemRenderer : ComponentBase
    {
        [Parameter]
        public IDisplayableItem Item { get; set; }

        private static int index = 0;

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Item is Icon icon)
            {
                RenderIcon(builder, icon);
                return;
            }

            if (Item is ColorItem colorItem)
            {
                RenderColoredSpan(builder, colorItem);
                return;
            }

            RenderSpan(builder, Item);
        }


        private static void RenderIcon(RenderTreeBuilder builder, Icon icon)
        {
            if (icon == Icon.Even) Render<EvenIcon>(builder);
            if (icon == Icon.Odd) Render<OddIcon>(builder);
            if (icon == Icon.Sum) Render<SumIcon>(builder);
        }

        private static void Render<T>(RenderTreeBuilder builder) where T : IComponent
        {
            builder.OpenComponent<T>(index++);
            builder.CloseComponent();
        }

        private static void RenderColoredSpan(RenderTreeBuilder builder, ColorItem item)
        {
            builder.OpenElement(index++, "span");
            builder.AddAttribute(index++, "style", $"background-color:#{item.Color.Hex}");
            builder.AddAttribute(index++, "class", "w-3 mx-0.5 rounded-sm");
            builder.AddAttribute(index++, "title", item.Color);
            if (item.HasNumber)
            {
                builder.AddMarkupContent(index++, item.Number.ToString());
            }
            builder.CloseElement();
        }

        private static void RenderSpan(RenderTreeBuilder builder, IDisplayableItem item)
        {
            builder.OpenElement(index++, "span");
            builder.AddMarkupContent(index++, item.ToString());
            builder.CloseElement();
        }
    }
}
