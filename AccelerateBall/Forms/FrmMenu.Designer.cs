
namespace AccelerateBall.Forms
{
    partial class FrmMenu
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("", -1);
            this.panelFill = new Infragistics.Win.Misc.UltraPanel();
            this.panelContent = new Infragistics.Win.Misc.UltraPanel();
            this.grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panelFillTop = new Sunny.UI.UIPanel();
            this.uiSwitch = new Sunny.UI.UISwitch();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.panelTop = new Infragistics.Win.Misc.UltraPanel();
            this.uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            this.uiImageButton1 = new Sunny.UI.UIImageButton();
            this.uiImageButton2 = new Sunny.UI.UIImageButton();
            this.panelFill.ClientArea.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelContent.ClientArea.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelFillTop.SuspendLayout();
            this.panelTop.ClientArea.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFill
            // 
            appearance1.BackColor = System.Drawing.Color.White;
            appearance1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelFill.Appearance = appearance1;
            this.panelFill.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            // 
            // panelFill.ClientArea
            // 
            this.panelFill.ClientArea.Controls.Add(this.panelContent);
            this.panelFill.ClientArea.Controls.Add(this.panelTop);
            this.panelFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFill.Location = new System.Drawing.Point(0, 0);
            this.panelFill.Name = "panelFill";
            this.panelFill.Size = new System.Drawing.Size(172, 296);
            this.panelFill.TabIndex = 2;
            // 
            // panelContent
            // 
            // 
            // panelContent.ClientArea
            // 
            this.panelContent.ClientArea.Controls.Add(this.grid);
            this.panelContent.ClientArea.Controls.Add(this.panelFillTop);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 78);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(170, 216);
            this.panelContent.TabIndex = 3;
            // 
            // grid
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.Name = "微软雅黑";
            appearance2.FontData.SizeInPoints = 12F;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grid.DisplayLayout.Appearance = appearance2;
            ultraGridBand1.ColHeadersVisible = false;
            this.grid.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid.DisplayLayout.NoDataSourceMessageText = "请直接开门后将耗材放入柜中！确保称重耗材放入正确的存放位置！扫码耗材无需扫码放入！";
            this.grid.DisplayLayout.Override.NoRowsInDataSourceMessageText = "没有取用记录";
            this.grid.DisplayLayout.Override.NoVisibleRowsMessageText = "没有匹配到相应的筛选结果";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 54);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(170, 162);
            this.grid.TabIndex = 2;
            this.grid.Text = "ultraGrid1";
            // 
            // panelFillTop
            // 
            this.panelFillTop.Controls.Add(this.uiSwitch);
            this.panelFillTop.Controls.Add(this.uiLabel1);
            this.panelFillTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFillTop.FillColor = System.Drawing.Color.White;
            this.panelFillTop.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panelFillTop.IsScaled = false;
            this.panelFillTop.Location = new System.Drawing.Point(0, 0);
            this.panelFillTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFillTop.MinimumSize = new System.Drawing.Size(1, 1);
            this.panelFillTop.Name = "panelFillTop";
            this.panelFillTop.Radius = 0;
            this.panelFillTop.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelFillTop.Size = new System.Drawing.Size(170, 54);
            this.panelFillTop.Style = Sunny.UI.UIStyle.Custom;
            this.panelFillTop.TabIndex = 3;
            this.panelFillTop.Text = null;
            this.panelFillTop.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiSwitch
            // 
            this.uiSwitch.Active = true;
            this.uiSwitch.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(202)))), ((int)(((byte)(115)))));
            this.uiSwitch.ActiveText = "";
            this.uiSwitch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSwitch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitch.InActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.uiSwitch.InActiveText = "";
            this.uiSwitch.IsScaled = false;
            this.uiSwitch.Location = new System.Drawing.Point(106, 14);
            this.uiSwitch.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitch.Name = "uiSwitch";
            this.uiSwitch.Size = new System.Drawing.Size(53, 27);
            this.uiSwitch.Style = Sunny.UI.UIStyle.Custom;
            this.uiSwitch.TabIndex = 1;
            this.uiSwitch.ValueChanged += new Sunny.UI.UISwitch.OnValueChanged(this.uiSwitch_ValueChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(4, 9);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(96, 35);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "加速球置顶";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTop
            // 
            // 
            // panelTop.ClientArea
            // 
            this.panelTop.ClientArea.Controls.Add(this.uiTableLayoutPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(170, 78);
            this.panelTop.TabIndex = 2;
            // 
            // uiTableLayoutPanel1
            // 
            this.uiTableLayoutPanel1.ColumnCount = 2;
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Controls.Add(this.uiImageButton2, 1, 0);
            this.uiTableLayoutPanel1.Controls.Add(this.uiImageButton1, 0, 0);
            this.uiTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            this.uiTableLayoutPanel1.RowCount = 1;
            this.uiTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiTableLayoutPanel1.Size = new System.Drawing.Size(170, 78);
            this.uiTableLayoutPanel1.TabIndex = 0;
            this.uiTableLayoutPanel1.TagString = null;
            // 
            // uiImageButton1
            // 
            this.uiImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiImageButton1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton1.Image = global::AccelerateBall.Properties.Resources.开机加速;
            this.uiImageButton1.ImageHover = global::AccelerateBall.Properties.Resources.开机加速选中;
            this.uiImageButton1.ImagePress = global::AccelerateBall.Properties.Resources.开机加速选中;
            this.uiImageButton1.ImageSelected = global::AccelerateBall.Properties.Resources.开机加速选中;
            this.uiImageButton1.Location = new System.Drawing.Point(3, 3);
            this.uiImageButton1.Name = "uiImageButton1";
            this.uiImageButton1.Size = new System.Drawing.Size(79, 72);
            this.uiImageButton1.TabIndex = 0;
            this.uiImageButton1.TabStop = false;
            // 
            // uiImageButton2
            // 
            this.uiImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiImageButton2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButton2.Image = global::AccelerateBall.Properties.Resources.全面体检;
            this.uiImageButton2.ImageHover = global::AccelerateBall.Properties.Resources.全面体检选中;
            this.uiImageButton2.ImagePress = global::AccelerateBall.Properties.Resources.全面体检选中;
            this.uiImageButton2.ImageSelected = global::AccelerateBall.Properties.Resources.全面体检选中;
            this.uiImageButton2.Location = new System.Drawing.Point(88, 3);
            this.uiImageButton2.Name = "uiImageButton2";
            this.uiImageButton2.Size = new System.Drawing.Size(79, 72);
            this.uiImageButton2.TabIndex = 1;
            this.uiImageButton2.TabStop = false;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 296);
            this.Controls.Add(this.panelFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TopMost = true;
            this.MouseLeave += new System.EventHandler(this.FrmMenu_MouseLeave);
            this.panelFill.ClientArea.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelContent.ClientArea.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelFillTop.ResumeLayout(false);
            this.panelTop.ClientArea.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel panelFill;
        private Infragistics.Win.Misc.UltraPanel panelTop;
        private Infragistics.Win.Misc.UltraPanel panelContent;
        private Infragistics.Win.UltraWinGrid.UltraGrid grid;
        private Sunny.UI.UIPanel panelFillTop;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISwitch uiSwitch;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIImageButton uiImageButton2;
        private Sunny.UI.UIImageButton uiImageButton1;
    }
}