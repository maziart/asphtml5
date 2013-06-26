using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    [PersistChildren(true), ParseChildren(false)]
    public abstract class SVGControl : WebControl, IAttributeAccessor
    {
        public string CssClass { get { return GetViewState("CssClass", string.Empty); } set { SetViewState("CssClass", value); } }

        private SVGControlType Type;
        public new AttributeCollection Attributes { get; private set; }
        private StateBag AttributesBag;
        public SVGControl(SVGControlType type)
        {
            Type = type;
            AttributesBag = new StateBag(true);
            Attributes = new AttributeCollection(AttributesBag);
        }
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            foreach (var control in Controls.OfType<SVGControl>())
            {
                control.LoadViewState(savedState);
            }
        }

        private static string GetControlTypeTag(SVGControlType type)
        {
            return type.ToString().ToLower();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            AddAttributesToRender(writer);
            AddStyleAttributes(writer);
            Helper.AddStringAttributeIfNotEmpty(writer, "id", ClientID);
            Helper.AddStringAttributeIfNotEmpty(writer, "transform", Transform == null ? null : Transform.ToString());
            writer.RenderBeginTag(GetElementTag());
            foreach (var control in Controls.OfType<SVGControl>().OrderBy(n => n.ZIndex ?? 10)
                .Union(Controls.Cast<Control>().Where(n => !(n is SVGControl))))
            {
                control.RenderControl(writer);
            }
            writer.RenderEndTag();
        }

        protected virtual void AddStyleAttributes(HtmlTextWriter writer)
        {
            if (RenderStylesAsAttributes)
                AddStandaloneStyleAttributes(writer);
            else
                AddStyleAttribute(writer);
        }

        protected virtual void AddStyleAttribute(HtmlTextWriter writer)
        {
            Helper.AddStringAttributeIfNotEmpty(writer, "style", Style.GetSingleAttributeValue());
        }

        protected virtual void AddStandaloneStyleAttributes(HtmlTextWriter writer)
        {
            foreach (var key in Style.Keys)
            {
                Helper.AddStringAttributeIfNotEmpty(writer, key, Style[key]);
            }
        }
        protected virtual void AddAttributesToRender(HtmlTextWriter writer)
        {
            Helper.AddStringAttributeIfNotEmpty(writer, "class", CssClass);
            foreach (string key in Attributes.Keys)
            {
                writer.AddAttribute(key, Attributes[key]);
            }
        }

        protected virtual string GetElementTag()
        {
            return Type.ToString().ToLower();
        }

        public string GetAttribute(string key)
        {
            return Attributes[key];
        }

        public void SetAttribute(string key, string value)
        {
            Attributes[key] = value;

        }


        /// <summary>
        /// Fetches a value from ViewState and returns default value of the type if it does not exist
        /// </summary>
        /// <typeparam name="T">Type of the object desired to fetch</typeparam>
        /// <param name="key">Key to retrieve the object</param>
        /// <returns>Value in ViewState and default if ViewState does not contain the key</returns>
        protected virtual T GetViewState<T>(string key)
        {
            return GetViewState<T>(key, default(T));
        }
        /// <summary>
        /// Fetches a value from ViewState and returns the defaultValue provided if it does not exist
        /// </summary>
        /// <typeparam name="T">Type of the object desired to fetch</typeparam>
        /// <param name="key">Key to retrieve the object</param>
        /// <param name="defaultValue">The desired default value if ViewState does not contain the key</param>
        /// <returns>Value in ViewState and defaultValue if ViewState does not contain the key</returns>
        protected virtual T GetViewState<T>(string key, T defaultValue)
        {
            var value = ViewState[key];
            if (value == null)
                return defaultValue;
            return (T)value;
        }


        /// <summary>
        /// Saves an object in the ViewState of the control
        /// </summary>
        /// <param name="key">Key to store the object</param>
        /// <param name="value">The value to store</param>
        protected virtual T SetViewState<T>(string key, T value)
        {
            ViewState[key] = value;
            return value;
        }

        private SvgStyle _Style;
        public SvgStyle Style
        {
            get
            {
                return _Style ?? (_Style = new SvgStyle(ViewState));
            }
        }

        public bool RenderStylesAsAttributes { get { return GetViewState("RenderStylesAsAttributes", false); } set { SetViewState("RenderStylesAsAttributes", value); } }

        public TransformCommand Transform { get { return GetViewState<TransformCommand>("Transform", null); } set { SetViewState("Transform", value); } }

        public int? ZIndex { get { return GetViewState("ZIndex", (int?)null); } set { SetViewState("ZIndex", value); } }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
    }
}
