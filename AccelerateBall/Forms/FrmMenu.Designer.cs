
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.panelFill = new Infragistics.Win.Misc.UltraPanel();
            this.panelContent = new Infragistics.Win.Misc.UltraPanel();
            this.grid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.panelContentTop = new Infragistics.Win.Misc.UltraPanel();
            this.checkTop = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.panelTop = new Infragistics.Win.Misc.UltraPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxStartOpen = new System.Windows.Forms.PictureBox();
            this.pictureBoxAllCheck = new System.Windows.Forms.PictureBox();
            this.panelFill.ClientArea.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelContent.ClientArea.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelContentTop.ClientArea.SuspendLayout();
            this.panelContentTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkTop)).BeginInit();
            this.panelTop.ClientArea.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllCheck)).BeginInit();
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
            this.panelFill.Size = new System.Drawing.Size(213, 318);
            this.panelFill.TabIndex = 2;
            // 
            // panelContent
            // 
            // 
            // panelContent.ClientArea
            // 
            this.panelContent.ClientArea.Controls.Add(this.grid);
            this.panelContent.ClientArea.Controls.Add(this.panelContentTop);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 78);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(211, 238);
            this.panelContent.TabIndex = 3;
            // 
            // grid
            // 
            appearance2.BackColor = System.Drawing.Color.White;
            appearance2.FontData.Name = "微软雅黑";
            appearance2.FontData.SizeInPoints = 12F;
            appearance2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.grid.DisplayLayout.Appearance = appearance2;
            this.grid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grid.DisplayLayout.NoDataSourceMessageText = "请直接开门后将耗材放入柜中！确保称重耗材放入正确的存放位置！扫码耗材无需扫码放入！";
            this.grid.DisplayLayout.Override.NoRowsInDataSourceMessageText = "没有取用记录";
            this.grid.DisplayLayout.Override.NoVisibleRowsMessageText = "没有匹配到相应的筛选结果";
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 29);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(211, 209);
            this.grid.TabIndex = 2;
            this.grid.Text = "ultraGrid1";
            // 
            // panelContentTop
            // 
            // 
            // panelContentTop.ClientArea
            // 
            this.panelContentTop.ClientArea.Controls.Add(this.checkTop);
            this.panelContentTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContentTop.Location = new System.Drawing.Point(0, 0);
            this.panelContentTop.Name = "panelContentTop";
            this.panelContentTop.Size = new System.Drawing.Size(211, 29);
            this.panelContentTop.TabIndex = 3;
            // 
            // checkTop
            // 
            this.checkTop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.Name = "微软雅黑";
            appearance3.FontData.SizeInPoints = 13F;
            this.checkTop.Appearance = appearance3;
            appearance4.FontData.Name = "微软雅黑";
            appearance4.FontData.SizeInPoints = 13F;
            this.checkTop.CheckedAppearance = appearance4;
            this.checkTop.Location = new System.Drawing.Point(11, 0);
            this.checkTop.Name = "checkTop";
            this.checkTop.Size = new System.Drawing.Size(201, 29);
            this.checkTop.TabIndex = 0;
            this.checkTop.Text = "是否置顶显示";
            this.checkTop.CheckedChanged += new System.EventHandler(this.checkTop_CheckedChanged);
            // 
            // panelTop
            // 
            // 
            // panelTop.ClientArea
            // 
            this.panelTop.ClientArea.Controls.Add(this.tableLayoutPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(211, 78);
            this.panelTop.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxStartOpen, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxAllCheck, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(211, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxStartOpen
            // 
            this.pictureBoxStartOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxStartOpen.Image = global::AccelerateBall.Properties.Resources.开机加速;
            this.pictureBoxStartOpen.Location = new System.Drawing.Point(105, 0);
            this.pictureBoxStartOpen.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxStartOpen.Name = "pictureBoxStartOpen";
            this.pictureBoxStartOpen.Size = new System.Drawing.Size(106, 78);
            this.pictureBoxStartOpen.TabIndex = 1;
            this.pictureBoxStartOpen.TabStop = false;
            this.pictureBoxStartOpen.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxStartOpen.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxAllCheck
            // 
            this.pictureBoxAllCheck.BackColor = System.Drawing.Color.White;
            this.pictureBoxAllCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAllCheck.Image = global::AccelerateBall.Properties.Resources.全面体检;
            this.pictureBoxAllCheck.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAllCheck.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxAllCheck.Name = "pictureBoxAllCheck";
            this.pictureBoxAllCheck.Size = new System.Drawing.Size(105, 78);
            this.pictureBoxAllCheck.TabIndex = 0;
            this.pictureBoxAllCheck.TabStop = false;
            this.pictureBoxAllCheck.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxAllCheck.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 318);
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
            this.panelContentTop.ClientArea.ResumeLayout(false);
            this.panelContentTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkTop)).EndInit();
            this.panelTop.ClientArea.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStartOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Infragistics.Win.Misc.UltraPanel panelFill;
        private Infragistics.Win.Misc.UltraPanel panelTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxStartOpen;
        private System.Windows.Forms.PictureBox pictureBoxAllCheck;
        private Infragistics.Win.Misc.UltraPanel panelContent;
        private Infragistics.Win.UltraWinGrid.UltraGrid grid;
        private Infragistics.Win.Misc.UltraPanel panelContentTop;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor checkTop;
    }
}