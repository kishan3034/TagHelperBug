using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace TagHelperBug.TagHelpers
{


    /// <summary>
    /// Panel body helper for rendering a BS 3.3.X panel.
    /// </summary>
    [HtmlTargetElement("panel-body", ParentTag = "panel")]
    public class PanelBodyTagHelper : TagHelper
    {
        /// <summary>
        /// The constants defined by Boostrap 3.3 for Panels.
        /// 
        /// Added templating in for the extra CSS and ID.
        /// </summary>
        struct PanelConstants
        {
            public const string PANEL_CLASS_DEFAULT = "panel-body";
            public const string PANEL_OPEN_TAG = "<div class='panel-body {0}' id='{1}'>";
            public const string PANEL_CLOSE_TAG = "</div>";
        }

        /// <summary>
        /// The Panel Body's ID to use if specified.
        /// </summary>
        public string PanelBodyID { get; set; }

        /// <summary>
        /// The Extra CSS to apply to the panel-body.
        /// </summary>
        public string PanelBodyCSS { get; set; } = PanelConstants.PANEL_CLASS_DEFAULT;

        /// <summary>
        /// Overrides the process Async to create the Panel Body of a BS panel.  This will set the 
        /// body to the PanelContext's Body property and not output a tag here.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override /*async Task ProcessAsync*/void Process(TagHelperContext context, TagHelperOutput output)
        {
            ////Get the content betweent the open and close tags.
            //var childContent =  output.GetChildContentAsync().GetAwaiter().GetResult();

            //var bodyContent = new DefaultTagHelperContent();

            //bodyContent.AppendFormat(string.Format(PanelConstants.PANEL_OPEN_TAG, PanelBodyCSS, PanelBodyID));

            //bodyContent.AppendHtml(childContent);

            //bodyContent.AppendFormat(PanelConstants.PANEL_CLOSE_TAG);

            //var body = bodyContent.GetContent();

            //var panelContext = (PanelContext)context.Items[typeof(PanelTagHelper)];
            //panelContext.Body = bodyContent;
            //output.SuppressOutput();

            output.TagName = "div";
            output.Attributes.SetAttribute("class", $@"panel-body {PanelBodyCSS}");

            if (!string.IsNullOrEmpty(PanelBodyID))
            {
                output.Attributes.SetAttribute("id", PanelBodyID);
            }

        }
    }
}
