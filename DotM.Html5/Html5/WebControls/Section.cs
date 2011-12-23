using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a section of a document, typically with a title or heading.
    /// </summary>
    public class Section : ContainerControl
    {
        /// <summary>
        /// Creates a new instance of <c>Section</c>
        /// </summary>
        public Section() : base(ContainerType.Section) { }
    }
}
