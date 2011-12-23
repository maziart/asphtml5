using System.ComponentModel;
using System.Web.UI;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a control from which the user can obtain additional information or controls on-demand.
    /// </summary>
    public class Details : ContainerControl
    {
        /// <summary>
        /// Creates new instance of type <c>Details</c>
        /// </summary>
        public Details() : base(ContainerType.Details) { }

        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddBooleanAttribute(writer, "open", IsOpen);
        }

        /// <summary>
        /// Gets or sets a value which specifies that the contents of the details element should be shown to the user.
        /// </summary>
        [Themeable(false), DefaultValue(false), Category("Layout"), Description("Specifies that the contents of the details element should be shown to the user")]
        public bool IsOpen { get; set; }
    }
}
