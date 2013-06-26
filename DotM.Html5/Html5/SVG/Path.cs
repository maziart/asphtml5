using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace DotM.Html5.SVG
{
    /// <summary>
    /// Paths represent the outline of a shape which can be filled, stroked, used as a clipping path,
    /// or any combination of the three
    /// </summary>
    public class Path : LineBase
    {
        public Path()
            : base(SVGControlType.Path)
        {

        }
        protected override void AddAttributesToRender(System.Web.UI.HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddFloatAttributeIfNotDefault(writer, "pathLength", PathLength, 0);
            Helper.AddStringAttributeIfNotEmpty(writer, "d", Commands.GetPathData());
        }
        public float PathLength { get { return GetViewState("PathLength", 0f); } set { SetViewState("PathLength", value); } }
        public string Fill { get { return Style["Fill"]; } set { Style["Fill"] = value; } }

        private MoveCommand _StartFrom;
        public MoveCommand Commands
        {
            get { return _StartFrom ?? (_StartFrom = GetViewState("Commands", new MoveCommand(0, 0, true))); }
            set { _StartFrom = value; }
        }
        public MoveCommand StartFrom(double x, double y, bool absolute = true)
        {
            Commands.Set(x, y, absolute);
            return Commands;
        }
        public PathCommand LastCommand
        {
            get
            {
                return Commands.LastCommand;
            }
        }
        protected override void OnPreRender(EventArgs e)
        {
            SetViewState("Commands", _StartFrom);
            base.OnPreRender(e);
        }

    }
}
