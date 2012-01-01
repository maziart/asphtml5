﻿using System.ComponentModel;
using System.Web.UI;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a control for editing an absolute URL given in the element’s value.
    /// </summary>
    public class UrlInput : InputControl
    {
        /// <summary>
        /// Creates a new instance of type <c>UrlInput</c>
        /// </summary>
        public UrlInput() : base(InputType.Url) { }

        /// <summary>
        /// Gets or sets the selected Url
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("Selected Url"), UrlProperty]
        public string Value { get { return Text; } set { Text = value; } }
    }
}
