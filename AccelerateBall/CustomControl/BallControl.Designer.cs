
namespace AccelerateBall.CustomControl
{
    partial class BallControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BallPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // BallPanel
            // 
            this.BallPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BallPanel.Location = new System.Drawing.Point(0, 0);
            this.BallPanel.Name = "BallPanel";
            this.BallPanel.Size = new System.Drawing.Size(200, 100);
            this.BallPanel.TabIndex = 0;
            // 
            // BallControl
            // 
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.Size = new System.Drawing.Size(100, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BallPanel;
    }
}