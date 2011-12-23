using System.ComponentModel;
using System.Web.UI;
using DotM.Html5.WebControls;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Represents a control for setting the element’s value to a string representing a week.
    /// </summary>
    public class WeekInput : InputControl
    {
        /// <summary>
        /// Creates a new instance of <c>WeekInput</c>
        /// </summary>
        public WeekInput() : base(InputType.Week) { }

        /// <summary>
        /// Gets or sets the selected WeekOfYear
        /// </summary>
        [Themeable(false), Category("Behavior"), Description("Selected Week-Of-Year")]
        public WeekOfYear Value
        {
            get
            {
                if (string.IsNullOrEmpty(Text))
                    return WeekOfYear.Empty;
                return WeekOfYear.Parse(Text);
            }
            set
            {
                if (WeekOfYear.IsEmpty(value))
                    Text = string.Empty;
                else
                    Text = value.ToString();
            }
        }
    }
}
