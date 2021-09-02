using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace AccelerateBall.CustomControl
{
    public partial class BallControl : Control
    {
        public BallControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // Graphics是一个画家，创建Graphics的参数pe是一个画板，Graphics进行绘画时需要使用Brush，Pen等作为工具
            // Graphics的函数则为行为
            var g = pe.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // 白色加点灰
            var brush = new SolidBrush(Color.WhiteSmoke);
            var rect = new Rectangle(0, 0, 130, 60);
            var path = CreateRoundedRectanglePath(rect, 30);
            g.FillPath(brush, path);

            // 深绿色
            brush = new SolidBrush(Color.FromArgb(51, 154, 56));
            g.FillEllipse(brush, 2, 2, 56, 56);

            // 淡绿
            brush = new SolidBrush(Color.GreenYellow);//填充的颜色         
            g.FillEllipse(brush, 4, 4, 52, 52);

            g.Dispose();
        }

        /// <summary>
        ///  将一个矩形变成一个椭圆，四个角都是弧形
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="cornerRadius"></param>
        /// <returns></returns>
        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            int diameter = cornerRadius * 2;
            // 在一个矩形的基础上实例化一个正方形，宽度为长方形的高度
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            // x轴顺时针方向，开始角度，结束角度

            // 左上角
            path.AddArc(arcRect, 180, 90);

            // 右上角
            // 0
            arcRect.X = rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            // 右下角
            arcRect.Y = rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            // 左下角
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();//闭合曲线
            return path;
        }
    }
}
