using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Any ‘svg’, ‘symbol’, ‘g’, graphics element or other ‘use’ is potentially a template object that 
    /// can be re-used (i.e., "instanced") in the SVG document via a ‘use’ element. The ‘use’ element 
    /// references another element and indicates that the graphical contents of that element is included/drawn
    /// at that given point in the document.
    /// </summary>
    public class Use : SVGControl
    {
        public Use()
            :base(SVGControlType.Use)
        {
        }

        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddUnitAttributeIfNotEmpty(writer, "x", X);
            Helper.AddUnitAttributeIfNotEmpty(writer, "y", Y);
            Helper.AddUnitAttributeIfNotEmpty(writer, "width", Width);
            Helper.AddUnitAttributeIfNotEmpty(writer, "height", Height);
            var reference = FindReference(Reference);
            Helper.AddStringAttributeIfNotEmpty(writer, "xlink:href", reference);
        }

        private string FindReference(string reference)
        {
            if (string.IsNullOrEmpty(reference))
                return null;
            if (reference.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
                return reference;
            var control = FindControl(reference);
            if (control == null)
                return "#" + reference;
            return "#" + control.ClientID;
        }
        /// <summary>
        /// The x-axis coordinate of one corner of the rectangular region into which the referenced
        /// element is placed. If the attribute is not specified, the effect is as if a value of "0" were specified.
        /// </summary>
        public Unit X { get { return GetViewState("X", Unit.Empty); } set { SetViewState("X", value); } }
        /// <summary>
        /// The y-axis coordinate of one corner of the rectangular region into which the referenced element is placed.
        /// If the attribute is not specified, the effect is as if a value of "0" were specified.
        /// </summary>
        public Unit Y { get { return GetViewState("Y", Unit.Empty); } set { SetViewState("Y", value); } }
        /// <summary>
        /// The width of the rectangular region into which the referenced element is placed. A negative value is an error.
        /// A value of zero disables rendering of this element.
        /// </summary>
        public Unit Width { get { return GetViewState("Width", Unit.Empty); } set { SetViewState("Width", value); } }
        /// <summary>
        /// The height of the rectangular region into which the referenced element is placed. A negative value is an error.
        /// A value of zero disables rendering of this element.
        /// </summary>
        public Unit Height { get { return GetViewState("Height", Unit.Empty); } set { SetViewState("Height", value); } }
        /// <summary>
        /// An IRI reference to an element/fragment within an SVG document.
        /// </summary>
        public string Reference { get { return GetViewState("Reference", string.Empty); } set { SetViewState("Reference", value); } }
    }
}
