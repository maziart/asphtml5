using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a caption or legend for a figure.
    /// </summary>
    /// <remarks>This control can only be nested inside a <c>Figure</c> Control</remarks>
    public class FigCaption : ContainerControl
    {
        /// <summary>
        /// Creates a new instace of <c>FigCaption</c>
        /// </summary>
        public FigCaption() : base(ContainerType.FigCaption)
        {

        }
        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The System.Web.UI.HtmlTextWriter object that receives the control content.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when nested inside a type other than <c>Figure</c></exception>
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            var parent = this.Parent as Figure;
            if (parent == null)
                throw new InvalidOperationException("A FigCaption element can only nest inside a figure element");
            base.Render(writer);
        }
    }
}
