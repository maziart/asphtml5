using System.ComponentModel;
using System.Web.UI;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a control for setting the element’s value to a string representing a local date and time (with no timezone information).
    /// </summary>
    public class DateTimeLocalInput : InputControl
    {
        /// <summary>
        /// Creates a new instance of <c>DateTimeLocalInput</c>
        /// </summary>
        public DateTimeLocalInput() : base(InputType.DateTimeLocal) { }

        /// <summary>
        /// Gets or sets the selected DateTime
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("Selected DateTime")]
        public string Value //TODO change to DateTime
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the expected lower bound for the element’s value.
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("The expected lower bound for the element’s value.")]
        public string Minimum
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the expected upper bound for the element’s value.
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("The expected upper bound for the element’s value.")]
        public string Maximum
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets specifies the value granularity of the element’s value.
        /// </summary>
        [Themeable(false), DefaultValue(1), Category("Behavior"), Description("Specifies the value granularity of the element’s value")]
        public float Step { get { return _Step ?? 1; } set { _Step = value; } }

        private float? _Step;


        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddStringAttributeIfNotEmpty(writer, "min", Minimum);
            Helper.AddStringAttributeIfNotEmpty(writer, "max", Maximum);
            Helper.AddNullableFloatAttribute(writer, "step", _Step);
        }
    }
}
