﻿using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// An abstract class that provides different html 5 input type controls
    /// </summary>
    /// <remarks>Use of this class has been restricted to internal.</remarks>
    public abstract class InputControl : TextBox
    {
        internal InputType Type { get; private set; }
        internal InputControl(InputType type)
        {
            Type = type;
            Attributes["type"] = GetTypeAttributeName();
        }
        internal string GetTypeAttributeName()
        {
            switch (Type)
            {
                case InputType.Email:
                case InputType.Url:
                case InputType.Tel:
                case InputType.Number:
                case InputType.Color:
                case InputType.Date:
                case InputType.Month:
                case InputType.Week:
                case InputType.Time:
                case InputType.DateTime:
                case InputType.Search:
                case InputType.Text:
                case InputType.Range:
                    return Type.ToString().ToLower();
                case InputType.DateTimeLocal:
                    return "datetime-local";
                default:
                    throw new ArgumentOutOfRangeException("Type");
            }
        }
        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddStringAttributeIfNotEmpty(writer, "form", CreateFormAttributeValue());
            Helper.AddBooleanAttribute(writer, "required", Required);
            Helper.AddStringAttributeIfNotEmpty(writer, "placeholder", PlaceHolder);
            Helper.AddStringAttributeIfNotEmpty(writer, "pattern", Pattern);
            Helper.AddLowerCaseEnumIfNotZero(writer, "autocomplete", AutoComplete);
            Helper.AddStringAttributeIfNotEmpty(writer, "list", GetDataListRenderID(List));
        }

        internal virtual string CreateFormAttributeValue()
        {
            if (string.IsNullOrEmpty(FormID))
                return null;
            return GetFormRenderID(FormID);
        }
        internal string GetFormRenderID(string id)
        {
            if (this.Page == null || string.IsNullOrEmpty(id))
                return id;
            var form = Page.FindControl(id);
            if (form == null)
                return id;
            if (!(form is HtmlForm))
            {
                throw new InvalidOperationException("Form attribute must be related to a valid form element in page");
            }
            return form.ClientID;
        }

        internal string GetDataListRenderID(string name)
        {
            if (string.IsNullOrEmpty(name))
                return null;
            Control control = this.FindControl(name);
            if (control == null)
            {
                return name;
            }
            if (!(control is DataList))
                throw new InvalidOperationException("List property of html5:Text control should reference an html5:DataList control");
            return control.ClientID;
        }
        /// <summary>
        /// Gets or sets the ID of the DataList control with which to associate the element.
        /// </summary>
        [Category("Behavior"), Themeable(false), DefaultValue(""), IDReferenceProperty(typeof(DataList)), Description("ID of the html5:DataList Element to provide a list of suggestion values to this Text control")]
        public string List { get; set; }


        /// <summary>
        /// Gets or sets the value of the id attribute on the form with which to associate the element.
        /// </summary>
        [Description("The value of the id attribute on the form with which to associate the element"), DefaultValue(""), Category("Default")]
        public string FormID { get; set; }


        /// <summary>
        /// Gets or sets a value indicating that the browser should prevent user to leave this input blank
        /// </summary>
        [Themeable(false), DefaultValue(false), Category("Behavior"), Description("Tells the browser that this input is required and should be filled before post back")]
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets a string, when the input value is empty this text will be shown inside it
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("The text to be shown there input has no value")]        
        public string PlaceHolder { get; set; }
        
        /// <summary>
        /// Gets or sets the regular expression to validate the input
        /// </summary>
        [Themeable(false), DefaultValue(""), Category("Behavior"), Description("The regular expression to validate the input")]
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets value that specifies whether the element represents an input control for which a UA is meant to store the value entered by the user (so that the UA can prefill the form later).
        /// </summary>
        [Themeable(false), DefaultValue(InputAutoCompleteMode.NotSet), Category("Behavior"), Description("prevent browser to show previously input values")]
        public InputAutoCompleteMode AutoComplete { get; set; }

        /// <summary>
        /// Gets or sets value indicating if the initial focus of the page should be on this control
        /// </summary>
        [Themeable(false), DefaultValue(false), Category("Behavior"), Description("If set to true, the initial focus of the page will be on this control")]
        public bool AutoFocus { get; set; }



        #region Hidden Properties
        /// <summary>
        /// Hidden property <c>Text</c>
        /// </summary>
        /// <remarks>Do not use this property manually</remarks>
        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Hidden property <c>Rows</c>
        /// </summary>
        /// <remarks>Do not use this property manually</remarks>
        [Browsable(false)]
        public override int Rows
        {
            get
            {
                return base.Rows;
            }
            set
            {
                base.Rows = value;
            }
        }

        /// <summary>
        /// Hidden property <c>Columns</c>
        /// </summary>
        /// <remarks>Do not use this property manually</remarks>
        [Browsable(false)]
        public override int Columns
        {
            get
            {
                return base.Columns;
            }
            set
            {
                base.Columns = value;
            }
        }

        /// <summary>
        /// Hidden property <c>TextMode</c>
        /// </summary>
        /// <remarks>Do not use this property manually</remarks>
        [Browsable(false)]
        public override TextBoxMode TextMode
        {
            get
            {
                return TextBoxMode.SingleLine;
            }
            set
            {
            }
        }
        #endregion
    }
}
