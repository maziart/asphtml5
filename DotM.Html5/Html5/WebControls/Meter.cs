using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.ComponentModel;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a scalar gauge providing a measurement within a known range, or a fractional value
    /// </summary>
    [Description("represents a scalar gauge providing a measurement within a known range, or a fractional value")]
    public class Meter : WebControl
    {
        private float? _Minimum;
        private float? _Maximum;
        private float? _Value;
        private float? _Low;
        private float? _High;
        private float? _Optimum;

        /// <summary>
        /// Creates a new instance of <c>Meter</c>
        /// </summary>
        public Meter() : base("meter") { }

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
            Helper.AddNullableFloatAttribute(writer, "value", _Value);
            Helper.AddNullableFloatAttribute(writer, "low", _Low);
            Helper.AddNullableFloatAttribute(writer, "high", _High);
            Helper.AddNullableFloatAttribute(writer, "optimum", _Optimum);
        }

        /// <summary>
        /// Gets or sets lower bound of the range for the meter
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("The lower bound of the range for the meter")]
        public float Minimum { get { return _Minimum ?? 0; } set { _Minimum = value; } }

        /// <summary>
        /// Gets or sets the upper bound of the range for the meter
        /// </summary>
        [Themeable(false), DefaultValue(1), Category("Behavior"), Description("The upper bound of the range for the meter")]
        public float Maximum { get { return _Maximum ?? 1; } set { _Maximum = value; } }

        /// <summary>
        /// Gets or sets the “measured” value shown by meter
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("The “measured” value shown by meter")]
        public float Value { get { return _Value ?? Minimum; } set { _Value = value; } }


        /// <summary>
        /// Gets or sets the point that marks the upper boundary of the “low” segment of the meter
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("The point that marks the upper boundary of the “low” segment of the meter")]
        public float Low { get { return _Low ?? Minimum; } set { _Low = value; } }


        /// <summary>
        /// Gets or sets the point that marks the lower boundary of the “high” segment of the meter.
        /// </summary>
        [Themeable(false), DefaultValue(1), Category("Behavior"), Description("The point that marks the lower boundary of the “high” segment of the meter")]
        public float High { get { return _High ?? Maximum; } set { _High = value; } }


        /// <summary>
        /// Gets or sets the point that marks the “optimum” position for the meter
        /// </summary>
        [Themeable(false), DefaultValue(0), Category("Behavior"), Description("The point that marks the “optimum” position for the meter")]
        public float Optimum { get { return _Optimum ?? Value; } set { _Optimum = value; } }

    }
}
