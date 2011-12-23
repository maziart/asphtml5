using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotM.Html5.WebControls
{
    /// <summary>
    /// An abstract class that acts like a panel and is a container control;
    /// </summary>
    /// <remarks>Use of this class has been restricted to internal.</remarks>
    [PersistChildren(true), ParseChildren(false)]
    public abstract class ContainerControl : WebControl
    {
        internal ContainerType Type { get; private set; }
        internal ContainerControl(ContainerType type)
            : base(GetTypeTagName(type))
        {
            Type = type;
        }
        internal static string GetTypeTagName(ContainerType type)
        {
            return type.ToString().ToLower();
        }
        
        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            string backImageUrl = this.BackImageUrl;
            if (backImageUrl.Trim().Length > 0)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundImage, "url(" + base.ResolveClientUrl(backImageUrl) + ")");
            }
            this.AddScrollingAttribute(this.ScrollBars, writer);
            HorizontalAlign horizontalAlign = this.HorizontalAlign;
            if (horizontalAlign != HorizontalAlign.NotSet)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(HorizontalAlign));
                writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, converter.ConvertToInvariantString(horizontalAlign).ToLowerInvariant());
            }
            if (!this.Wrap)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.WhiteSpace, "nowrap");
            }
            if (this.Direction == ContentDirection.LeftToRight)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Dir, "ltr");
            }
            else if (this.Direction == ContentDirection.RightToLeft)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Dir, "rtl");
            }
        }

        private void AddScrollingAttribute(ScrollBars scrollBars, HtmlTextWriter writer)
        {
            switch (scrollBars)
            {
                case ScrollBars.Horizontal:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.OverflowX, "scroll");
                    return;

                case ScrollBars.Vertical:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.OverflowY, "scroll");
                    return;

                case ScrollBars.Both:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Overflow, "scroll");
                    return;

                case ScrollBars.Auto:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Overflow, "auto");
                    return;
            }
        }
        /// <summary>
        /// Creates the style object that is used internally by the System.Web.UI.WebControls.WebControl
        /// class to implement all style related properties. This method is used primarily by control developers.
        /// </summary>
        /// <returns>A System.Web.UI.WebControls.Style that is used to implement all style-related properties of the control.</returns>
        protected override Style CreateControlStyle()
        {
            return new PanelStyle(this.ViewState);
        }
        /// <summary>
        /// Renders the HTML opening tag of the control to the specified writer. This method is used primarily by control developers.
        /// </summary>
        /// <param name="writer">A System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client.</param>
        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            this.AddAttributesToRender(writer);
            HtmlTextWriterTag tagKey = this.TagKey;
            if (tagKey != HtmlTextWriterTag.Unknown)
            {
                writer.RenderBeginTag(tagKey);
            }
            else
            {
                writer.RenderBeginTag(this.TagName);
            }
        }

        /// <summary>
        /// Gets or sets an Image Url for background of the control
        /// </summary>
        [Category("Appearance"), UrlProperty, Description("Panel BackImageUrl"), DefaultValue("")]
        public virtual string BackImageUrl
        {
            get
            {
                if (base.ControlStyleCreated)
                {
                    PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                    if (controlStyle != null)
                    {
                        return controlStyle.BackImageUrl;
                    }
                    string str = (string)this.ViewState["BackImageUrl"];
                    if (str != null)
                    {
                        return str;
                    }
                }
                return string.Empty;
            }
            set
            {
                PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                if (controlStyle != null)
                {
                    controlStyle.BackImageUrl = value;
                }
                else
                {
                    this.ViewState["BackImageUrl"] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the content direction of the control
        /// </summary>
        [DefaultValue(0), Description("Panel Direction"), Category("Layout")]
        public virtual ContentDirection Direction
        {
            get
            {
                if (base.ControlStyleCreated)
                {
                    PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                    if (controlStyle != null)
                    {
                        return controlStyle.Direction;
                    }
                    object obj2 = this.ViewState["Direction"];
                    if (obj2 != null)
                    {
                        return (ContentDirection)obj2;
                    }
                }
                return ContentDirection.NotSet;
            }
            set
            {
                PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                if (controlStyle != null)
                {
                    controlStyle.Direction = value;
                }
                else
                {
                    this.ViewState["Direction"] = value;
                }
            }
        }

        
        /// <summary>
        /// Gets of sets the horisontal align of the control
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        [DefaultValue(0), Category("Layout"), Description("HorizontalAlign")]
        public virtual HorizontalAlign HorizontalAlign
        {
            get
            {
                if (base.ControlStyleCreated)
                {
                    PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                    if (controlStyle != null)
                    {
                        return controlStyle.HorizontalAlign;
                    }
                    object obj2 = this.ViewState["HorizontalAlign"];
                    if (obj2 != null)
                    {
                        return (HorizontalAlign)obj2;
                    }
                }
                return HorizontalAlign.NotSet;
            }
            set
            {
                PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                if (controlStyle != null)
                {
                    controlStyle.HorizontalAlign = value;
                }
                else
                {
                    if ((value < HorizontalAlign.NotSet) || (value > HorizontalAlign.Justify))
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    this.ViewState["HorizontalAlign"] = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the scroll bars status for this control
        /// </summary>
        [Category("Layout"), Description("ScrollBars"), DefaultValue(0)]
        public virtual ScrollBars ScrollBars
        {
            get
            {
                if (base.ControlStyleCreated)
                {
                    PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                    if (controlStyle != null)
                    {
                        return controlStyle.ScrollBars;
                    }
                    object obj2 = this.ViewState["ScrollBars"];
                    if (obj2 != null)
                    {
                        return (ScrollBars)obj2;
                    }
                }
                return ScrollBars.None;
            }
            set
            {
                PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                if (controlStyle != null)
                {
                    controlStyle.ScrollBars = value;
                }
                else
                {
                    this.ViewState["ScrollBars"] = value;
                }
            }
        }


        /// <summary>
        /// Gets or sets wrap text status for this control
        /// </summary>
        [Description("Wrap"), Category("Layout"), DefaultValue(true)]
        public virtual bool Wrap
        {
            get
            {
                if (base.ControlStyleCreated)
                {
                    PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                    if (controlStyle != null)
                    {
                        return controlStyle.Wrap;
                    }
                    object obj2 = this.ViewState["Wrap"];
                    if (obj2 != null)
                    {
                        return (bool)obj2;
                    }
                }
                return true;
            }
            set
            {
                PanelStyle controlStyle = base.ControlStyle as PanelStyle;
                if (controlStyle != null)
                {
                    controlStyle.Wrap = value;
                }
                else
                {
                    this.ViewState["Wrap"] = value;
                }
            }
        }
    }
}
