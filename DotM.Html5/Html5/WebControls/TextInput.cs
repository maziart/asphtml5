using System.ComponentModel;
using System.Web.UI;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a one-line plain text edit control for the input element’s value.
    /// </summary>
    public class TextInput : InputControl
    {
        /// <summary>
        /// Creates new instance of <see cref="DotM.Html5.WebControls.TextInput" />
        /// </summary>
        public TextInput() : base(InputType.Text) { }

        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddStringAttributeIfNotEmpty(writer, "dirname", DirName);
        }


        /// <summary>
        /// Gets or sets the selected text
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("Selected text")]
        public string Value { get { return Text; } set { Text = value; } }

        /// <summary>
        /// Gets or sets a value that enables submission of a rtl/ltr for of the element (If switched by user), and gives the name of the field that contains that value.
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("Enables submission of a value for the directionality of the element, and gives the name of the field that contains that value.")]
        public string DirName
        { get { return GetViewState("DirName", string.Empty); } set { SetViewState("DirName", value); } }

    }
}
