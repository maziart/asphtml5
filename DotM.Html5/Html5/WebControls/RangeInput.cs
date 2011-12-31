using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotM.Html5.WebControls
{
    /// <summary>
    ///  Represents an imprecise control for setting the element’s value to a string representing a number.
    /// </summary>
    public class RangeInput : NumberInput
    {
        /// <summary>
        /// Creates new instance of <c>RanceInput</c>
        /// </summary>
        public RangeInput() : base(InputType.Range) { }
    }
}
