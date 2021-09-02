
using AccelerateBall.CustomControl;

namespace AccelerateBall.Forms
{
    partial class FrmMinBall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMinBall));
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelUp = new Infragistics.Win.Misc.UltraLabel();
            this.labelDown = new Infragistics.Win.Misc.UltraLabel();
            this.ballControl = new AccelerateBall.CustomControl.BallControl();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelUp
            // 
            appearance1.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.labelUp.Appearance = appearance1;
            this.labelUp.Location = new System.Drawing.Point(59, 3);
            this.labelUp.Name = "labelUp";
            this.labelUp.Size = new System.Drawing.Size(54, 29);
            this.labelUp.TabIndex = 1;
            this.labelUp.Text = " 100 K/s";
            // 
            // labelDown
            // 
            appearance2.BackColor = System.Drawing.Color.WhiteSmoke;
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.labelDown.Appearance = appearance2;
            this.labelDown.Location = new System.Drawing.Point(59, 30);
            this.labelDown.Name = "labelDown";
            this.labelDown.Size = new System.Drawing.Size(54, 29);
            this.labelDown.TabIndex = 2;
            this.labelDown.Text = " 100 K/s";
            // 
            // ballControl
            // 
            this.ballControl.BackColor = System.Drawing.Color.White;
            this.ballControl.Location = new System.Drawing.Point(0, 0);
            this.ballControl.Name = "ballControl";
            this.ballControl.Size = new System.Drawing.Size(133, 59);
            this.ballControl.TabIndex = 0;
            this.ballControl.Text = "ballControl";
            this.ballControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BallControl_MouseDown);
            this.ballControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BallControl_MouseMove);
            this.ballControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BallControl_MouseUp);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "加速球";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideToolStripMenuItem,
            this.toolStripSeparator,
            this.ExitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(181, 76);
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            this.HideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.HideToolStripMenuItem.Text = "隐藏";
            this.HideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FrmMinBall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(133, 61);
            this.Controls.Add(this.labelDown);
            this.Controls.Add(this.labelUp);
            this.Controls.Add(this.ballControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmMinBall";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BallControl ballControl;
        private System.Windows.Forms.Timer timer;
        private Infragistics.Win.Misc.UltraLabel labelUp;
        private Infragistics.Win.Misc.UltraLabel labelDown;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem HideToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
    }
}