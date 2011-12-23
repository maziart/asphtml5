using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents the completion progress of a task
    /// </summary>
    [Description("Represents the completion progress of a task")]
    public class Progress : WebControl
    {
        private float? _Maximum;
        private float? _Value;
        /// <summary>
        /// Creates new instance of <c>Progress</c>
        /// </summary>
        public Progress() : base("progress") { }


        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddNullableFloatAttribute(writer, "max", _Maximum);
            Helper.AddNullableFloatAttribute(writer, "value", _Value);
        }

        /// <summary>
        /// Gets or sets the value taht specifies how much work the task requires in total
        /// </summary>
        [Themeable(false), DefaultValue(1), Category("Behavior"), Description("Specifies how much work the task requires in total")]
        public float Maximum { get { return _Maximum ?? 1; } set { _Maximum = value; } }

        /// <summary>
        /// Gets or sets the value that specifies how much of the task has been completed. 
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("Specifies how much of the task has been completed.")]
        public float Value { get { return _Value ?? 0; } set { _Value = value; } }
    }
}
