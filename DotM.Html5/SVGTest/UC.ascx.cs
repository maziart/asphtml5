using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotM.Html5.SVG;

namespace SVGTest
{
    public partial class UC : SVGUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PolyLine1.Points.Add("0 41");
                PolyLine1.Points.Add("30 0");
                PolyLine1.Points.Add("60 41");
                //PolyLine1.RenderStylesAsAttributes = true;

                MyPath.StartFrom(100, 200)
                    .CircleTo(100, 100, 250, 100, 250, 200, true)
                    .SmoothCircleTo(400, 300, 400, 200, true)
                    .MoveTo(200, 300)
                    .QuadricCurveTo(400, 50, 600, 300, true)
                    .SmoothQuadricCurveTo(1000, 300, true)
                    .MoveTo(600, 350)
                    .LineTo(50, -25)
                    .ArcTo(25, 25, -30, false, true, 50, -25)
                    .LineTo(50, -25)
                    .ArcTo(25, 50, -30, false, false, 50, -25)
                    .LineTo(50, -25)
                    .ArcTo(25, 75, -30, true, false, 50, -25)
                    .LineTo(50, -25)
                    .ArcTo(25, 100, -30, true, true, 50, -25)
                    .LineTo(50, -25)
                ;
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            PolyLine1.Points[1] = new Point(PolyLine1.Points[1].X, new Unit(PolyLine1.Points[1].Y.Value + 5));
           // house.Description += "Maziar";
            Path2.LastCommand.QuadricCurveTo(100, 10, 10, 10, true);

            var currentTranslate = Path2.Transform == null ? null : Path2.Transform.AsEnumerable().First(n => n.Type == TransformCommandType.Translate);
            if (currentTranslate == null)
            { 
                currentTranslate = new TransformCommand(TransformCommandType.Translate, 0, 0);
                if (Path2.Transform == null)
                    Path2.Transform = currentTranslate;
                else
                    Path2.Transform.Append(currentTranslate);
            }
            currentTranslate.Parameters[0] = currentTranslate.Parameters[0] + 10;
            var command = MyPath.LastCommand;
            command.HorizontalLineTo(10);
            Use1.ZIndex++;
        }
    }
}