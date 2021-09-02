using AccelerateBall.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AccelerateBall
{
    public partial class FrmMinBall : Form
    {

        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool isMouseDown;

        /// <summary>
        /// 鼠标移动起点
        /// </summary>
        private Point mouseOffset;

        /// <summary>
        /// 小球最小宽度
        /// </summary>
        public int minFormWidth = 132;

        /// <summary>
        /// 小球最小高度
        /// </summary>
        public int minFormHeight = 62;

        /// <summary>
        /// 右键弹出框
        /// </summary>
        public readonly FrmMenu frmMenu;

        private readonly MouseHook mouse = new MouseHook();

        public FrmMinBall()
        {
            InitializeComponent();
            frmMenu = new FrmMenu();
            mouse.OnMouseClickEvent += Mouse_OnMouseClickEvent;
            mouse.Start();
        }

        private void Mouse_OnMouseClickEvent(object sender, MouseEventArgs e)
        {
            if (frmMenu.Visible)
            {
                var xFlag = e.X < frmMenu.Location.X + frmMenu.Width && e.X > frmMenu.Location.X;
                var yFlag = e.Y > frmMenu.Location.Y && e.Y < frmMenu.Location.Y + frmMenu.Height;
                if (!xFlag || !yFlag)
                {
                    frmMenu.Hide();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Test();
        }

        public void Test()
        {
            var usedMemoryRate = "-1";

            var g = ballControl.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var color = Color.Black;
            if (usedMemoryRate.StartsWith("-"))
            {
                usedMemoryRate = usedMemoryRate.Replace("-", "");
                color = Color.Red;//填充的颜色
            }

            var x = usedMemoryRate.Length > 1 ? 16 : 21;
            var brush = new SolidBrush(color);
            g.DrawString(usedMemoryRate + "%", new Font("宋体", 14), brush, x, 21);
            g.Dispose();
        }

        private void BallControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseOffset = new Point(MousePosition.X - Location.X, MousePosition.Y - Location.Y);
                Cursor = Cursors.SizeAll;
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (!frmMenu.Visible)
                {
                    frmMenu.Show();
                    frmMenu.Location = GetLocation();
                }
            }
        }

        private void BallControl_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            Cursor = Cursors.Default;
        }

        private void BallControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown) Location = GetMinBallMoveLocation();
        }

        private Point GetMinBallMoveLocation()
        {
            int x = MousePosition.X - mouseOffset.X;
            int y = MousePosition.Y - mouseOffset.Y;
            if (x < 0) x = 0;
            if (y < 0) y = 0;
            if (Screen.PrimaryScreen.WorkingArea.Width - x < minFormWidth)
                x = Screen.PrimaryScreen.WorkingArea.Width - minFormWidth;

            if (Screen.PrimaryScreen.WorkingArea.Height - y < minFormHeight)
                y = Screen.PrimaryScreen.WorkingArea.Height - minFormHeight;

            return new Point(x, y);
        }

        private Point GetLocation()
        {
            int x, y;
            // 如果当前窗体的纵坐标大于大球的高度（即当前窗体在大球的下面）
            if (Location.Y >= frmMenu.Height)
            {
                // 屏幕的宽度减去当前窗体的X坐标位置小于大球的宽度（即小球的右侧宽度不够大球放）
                if (Screen.PrimaryScreen.WorkingArea.Width - Location.X <= frmMenu.Width)
                {
                    // 大球的x坐标为当前窗体的x坐标+小球的宽度-大球的宽度(即将大球显示在小球的左侧)
                    x = Location.X + minFormWidth - frmMenu.Width;
                }
                else
                {
                    x = Location.X;
                }
                y = Location.Y - frmMenu.Height;
            }
            else
            {
                if (Screen.PrimaryScreen.WorkingArea.Width - Location.X > frmMenu.Width)
                {
                    x = Location.X;
                }
                else
                {
                    x = Location.X + minFormWidth - frmMenu.Width;
                }
                y = Location.Y + minFormHeight;
            }
            return new Point(x, y);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            mouse.Stop();
        }
    }
}

