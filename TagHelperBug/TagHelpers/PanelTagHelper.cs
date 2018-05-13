using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using System.Diagnostics;

namespace TagHelperBug.TagHelpers
{
    /// <summary>
    /// The context for the child elements to relate to this element.
    /// </summary>
    [DebuggerDisplay("Body = {Body}")]
    public class PanelContext
    {
        public IHtmlContent Body { get; set; }
        public IHtmlContent Footer { get; set; }
    }

    /// <summary>
    /// Panel helper for rendering a BS 3.3.X panel.
    /// 
    /// <code>
    /// <panel panel-title="My Title" panel-icon="fas fa-check"></panel>
    /// </code>
    /// </summary>
    [RestrictChildren("panel-body", "panel-footer")]
    public class PanelTagHelper : TagHelper
    {
        #region Properties

        /// <summary>
        /// The title of the panel.
        /// </summary>
        public string PanelTitle { get; set; }

        /// <summary>
        /// The icon to have inside the panel title.
        /// </summary>
        public string PanelIcon { get; set; }

        /// <summary>
        /// A specific ID to assign to the panel.
        /// </summary>
        public string PanelID { get; set; }

        /// <summary>
        /// Special addition CSS to add to the panel.
        /// </summary>
        public string PanelCSS { get; set; }

        /// <summary>
        /// ID for specific button added to the panel header.
        /// </summary>
        public string PanelButtonID { get; set; }

        /// <summary>
        /// The CSS to apply to the panel header's button.
        /// </summary>
        public string PanelButtonCSS { get; set; }

        /// <summary>
        /// The tooltip to add to the panel button.
        /// </summary>
        public string PanelButtonToolTip { get; set; }

        /// <summary>
        /// The text to have on the panel button (if any).
        /// </summary>
        public string PanelButtonText { get; set; }
        /// <summary>
        /// Any specific JS that should be executed on the onclick event of the button.
        /// </summary>
        public string PanelButtonJS { get; set; }

        /// <summary>
        /// The icon that should be within the panel button (if any).
        /// </summary>
        public string PanelButtonIconCSS { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// The process method for turning the tag helper into a panel.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var panelContext = new PanelContext();

            //var panelTagHelper = typeof(PanelTagHelper);

            //
            //if (!context.Items.ContainsKey(panelTagHelper))
            //    context.Items.Add(panelTagHelper, panelContext);

            //var content = output.GetChildContentAsync().GetAwaiter().GetResult();

            PanelCSS = string.IsNullOrEmpty(PanelCSS) ? "" : PanelCSS;

            //string template;

            //If there isn't a button a button then use a template that contains no button.  Otherwise apply the clearfix
            //to the panel-heading.
            //if (PanelButtonCSS == null)
            //{
            //    template = $@"<div class='panel-heading'>
            //                            <div class='panel-title'><i class='{PanelIcon}'></i>&nbsp;{PanelTitle}
            //                            </div>
            //                        </div>
            //                        ";
            //}
            //else
            //{
            //    PanelButtonText = string.IsNullOrEmpty(PanelButtonText) ? string.Empty : $@"&nbsp;{PanelButtonText}";
            //    template = $@"<div class='panel-heading clearfix'>
            //                            <div class='panel-title'><i class='{PanelIcon}'></i>&nbsp;{PanelTitle}
            //                               <a id='{PanelButtonID}' title='{PanelButtonToolTip}' onclick='{PanelButtonJS}' class='{PanelButtonCSS}'><i class='{PanelButtonIconCSS}'></i>{PanelButtonText}</a>
            //                            </div>
            //                        </div>
            //                        ";
        //}


        //Set the TagHelper's Tag to a Div.
        output.TagName = "div";

            //Set the Tag's ID attribute.
            output.Attributes.SetAttribute("id", $@"{PanelID}");

            //Set the Tag's class attribute.
            output.Attributes.SetAttribute("class", $@"panel {PanelCSS}");

            //Add the Templated HTML
            //output.Content.AppendHtml(template);

            //If there is a panel-body, add that into the panel.
            //if (panelContext.Body != null)
            //{
            //    output.Content.AppendHtml(panelContext.Body);
            //}

            ////If there is a panel-foote, add that into the panel.
            //if (panelContext.Footer != null)
            //{
            //    output.Content.AppendHtml(panelContext.Footer);
            //}
        }
        #endregion
    }
}
