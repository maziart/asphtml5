using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a summary, caption, or legend for a details element.
    /// </summary>
    /// <remarks>This control can only be nested inside a <c>Details</c> Control</remarks>
    public class Summary : ContainerControl
    {
        /// <summary>
        /// Creates new instance of <c>Summary</c>
        /// </summary>
        public Summary() : base(ContainerType.Summary) { }

        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The System.Web.UI.HtmlTextWriter object that receives the control content.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when nested inside a type other than <c>Details</c></exception>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            var parent = this.Parent as Details;
            if (parent == null)
                throw new InvalidOperationException("A summary element can only nest inside a details element");
            base.Render(writer);
        }
    }
}
