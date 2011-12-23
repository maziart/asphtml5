﻿
namespace DotM.Html5.WebControls
{
    /// <summary>
    /// Specifies whether the element represents an input control for which a UA is meant to store the value entered by the user (so that the UA can prefill the form later).
    /// </summary>
    public enum InputAutoCompleteMode
    {
        /// <summary>
        /// Not rendered
        /// </summary>
        NotSet = 0,
        /// <summary>
        /// Enable AutoComplete
        /// </summary>
        On = 1,
        /// <summary>
        /// Disable AutoComplete
        /// </summary>
        Off = 2
    }
}
