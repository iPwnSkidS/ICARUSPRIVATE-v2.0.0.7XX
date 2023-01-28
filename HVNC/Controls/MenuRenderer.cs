using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShitarusPrivate.HVNC.Controls
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        private Color primaryColor;

        private Color textColor;

        private int arrowThickness;

        public MenuRenderer(bool isMainMenu, Color primaryColor, Color textColor)
            : base(new MenuColorTable(isMainMenu, primaryColor))
        {
            this.primaryColor = primaryColor;
            if (isMainMenu)
            {
                arrowThickness = 3;
                if (textColor == Color.Empty)
                {
                    this.textColor = Color.Gainsboro;
                }
                else
                {
                    this.textColor = textColor;
                }
            }
            else
            {
                arrowThickness = 2;
                if (textColor == Color.Empty)
                {
                    this.textColor = Color.DimGray;
                }
                else
                {
                    this.textColor = textColor;
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            base.OnRenderItemText(e);
            e.Item.ForeColor = (e.Item.Selected ? Color.White : textColor);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Size size = new Size(5, 12);
            Color color = (e.Item.Selected ? Color.White : primaryColor);
            Rectangle rectangle = new Rectangle(e.ArrowRectangle.Location.X, (e.ArrowRectangle.Height - size.Height) / 2, size.Width, size.Height);
            using GraphicsPath graphicsPath = new GraphicsPath();
            using Pen pen = new Pen(color, arrowThickness);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphicsPath.AddLine(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Top + rectangle.Height / 2);
            graphicsPath.AddLine(rectangle.Right, rectangle.Top + rectangle.Height / 2, rectangle.Left, rectangle.Top + rectangle.Height);
            graphics.DrawPath(pen, graphicsPath);
        }
    }
}
