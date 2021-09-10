using AccelerateBall.Utils;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccelerateBall.Forms
{
    public partial class FrmMinBall : Form
    {

        /// <summary>
        /// 上一次的圆球占比
        /// </summary>
        private string oldRate;

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

        private void FrmMinBall_Load(object sender, EventArgs e)
        {
            timer.Start();
            var instance = NetWorkSpeedMonitor.GetInstance();
            if (instance.Adapters.Count == 0)
            {
                NLogHelper.Error("没有检测到网卡信息");
                return;
            }
            instance.StartMonitoring();
            Task.Run(() => NetWorkMonitor(instance));
        }

        /// <summary>
        /// 网路监控
        /// </summary>
        private void NetWorkMonitor(NetWorkSpeedMonitor instance)
        {
            while (instance.Adapters.Count > 0)
            {
                double downSpeed = 0, uploadSpeed = 0;
                foreach (var item in instance.Adapters)
                {
                    downSpeed += item.DownloadSpeed;
                    uploadSpeed += item.UploadSpeed;
                }
                labelUp.UpdateUI(() => labelUp.Text = FormatNetSpeed(uploadSpeed));
                labelDown.UpdateUI(() => labelDown.Text = FormatNetSpeed(downSpeed));
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 只显示3位数字
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        private string FormatNetSpeed(double speed)
        {
            if (speed > 1024 * 10)
            {
                return $"{Math.Round(speed / 1024, 1)} M/s";
            }
            else if (speed > 1000)
            {
                return $"{Math.Round(speed / 1024, 2)} M/s";
            }
            else if (speed > 100)
            {
                return $"{Math.Round(speed)} K/s";
            }
            else if (speed > 10)
            {
                return $"{Math.Round(speed, 1)} K/s";
            }
            else
            {
                return $"{Math.Round(speed, 2)} K/s";
            }
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            var res = await HttpClientHelper.Get(AppConfig.CodeList);
            var newRate = res[0].Percentage;

            if (newRate != oldRate)
            {
                oldRate = newRate;
                PaintMiniBallControl(newRate);
            }
            if (frmMenu != null)
            {
                frmMenu.LoadData(res);
            }
        }

        public void PaintMiniBallControl(string usedMemoryRate)
        {
            var g = ballControl.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            // 覆盖之前填充的数据
            var brush = new SolidBrush(Color.GreenYellow);
            g.FillEllipse(brush, 4, 4, 52, 52);

            var color = Color.Black;
            if (usedMemoryRate.StartsWith("-"))
            {
                usedMemoryRate = usedMemoryRate.Replace("-", "");
                color = Color.Red;//填充的颜色
            }

            var x = usedMemoryRate.Length > 1 ? 16 : 21;
            brush = new SolidBrush(color);
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

        private void FrmMinBall_Click(object sender, EventArgs e)
        {
            mouse.Stop();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => Program.Exit();

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item)
                if (Visible)
                {
                    item.Text = "显示";
                    Hide();
                }
                else
                {
                    item.Text = "隐藏";
                    Show();
                }
        }
    }
}

