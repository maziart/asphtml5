using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a precise control for setting the element’s value to a string representing a number.
    /// </summary>
    public class NumberInput : InputControl
    {
        /// <summary>
        /// Creates a new instance of <c>NumberInput</c>
        /// </summary>
        public NumberInput() : base(InputType.Number) { }
        internal NumberInput(InputType type) : base(type) { }

        /// <summary>
        /// Gets or sets the expected lower bound for the element’s value
        /// </summary>
        [Themeable(false), DefaultValue(float.MinValue), Category("Behavior"), Description("The expected lower bound for the element’s value")]
        public float Minimum { get { return _Minimum ?? float.MinValue; } set { _Minimum = value; } }

        /// <summary>
        /// Gets or sets the expected upper bound for the element’s value
        /// </summary>
        [Themeable(false), DefaultValue(float.MinValue), Category("Behavior"), Description("The expected upper bound for the element’s value")]
        public float Maximum { get { return _Maximum ?? float.MaxValue; } set { _Maximum = value; } }

        /// <summary>
        /// Gets or sets the increment or decrement step
        /// </summary>
        [Themeable(false), DefaultValue(1), Category("Behavior"), Description("The increment or decrement step")]
        public float Step { get { return _Step ?? 1; } set { _Step = value; } }

        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddNullableFloatAttribute(writer, "min", _Minimum);
            Helper.AddNullableFloatAttribute(writer, "max", _Maximum);
            Helper.AddNullableFloatAttribute(writer, "step", _Step);
        }

        private float? _Minimum;
        private float? _Maximum;
        private float? _Step;


        /// <summary>
        /// Gets or sets the selected value
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("Selected value")]
        public float Value
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                    return 0;
                return float.Parse(Text);
            }
            set
            {
                Text = value.ToString();
            }
        }

        /// <summary>
        /// Gets a value showing if the 'Value' property has been set
        /// </summary>
        [Themeable(false), DefaultValue(false), Category("Behavior"), Description("Determines if Value has been set")]
        public bool HasValue
        {
            get
            {
                return !string.IsNullOrEmpty(Text);
            }
        }
    }
}
