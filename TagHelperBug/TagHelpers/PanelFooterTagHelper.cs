using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelperBug.TagHelpers
{
    /// <summary>
    /// Panel footer helper for rendering a BS 3.3.X panel.
    /// </summary>
    [HtmlTargetElement("panel-footer", ParentTag = "panel")]
    public class PanelFooterTagHelper : TagHelper
    {

        public string PanelBodyID { get; set; }


        public string PanelBodyCSS { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "panel-footer");

            if (!string.IsNullOrEmpty(PanelBodyID))
            {
                output.Attributes.SetAttribute("id", PanelBodyID);
            }
        }
    }

    
}
