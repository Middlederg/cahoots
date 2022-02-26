using Cahoots.Core;
using Cahoots.Web.Shared.Icons;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Cahoots.Web.Shared
{
    public class IconRenderer : ComponentBase
    {
        [Parameter] 
        public Icon Icon { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if (Icon == Icon.Even) Render<EvenIcon>(builder);
            if (Icon == Icon.Odd) Render<OddIcon>(builder);
            if (Icon == Icon.Sum) Render<SumIcon>(builder);
        }

        private static void Render<T>(RenderTreeBuilder builder) where T : IComponent
        {
            builder.OpenComponent<T>(1);
            builder.CloseComponent();
        }
    }
}
