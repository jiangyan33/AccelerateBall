
namespace AccelerateBall
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
            this.panelFill = new Infragistics.Win.Misc.UltraPanel();
            this.panelContent = new Infragistics.Win.Misc.UltraPanel();
            this.panelTop = new Infragistics.Win.Misc.UltraPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxStartOpen = new System.Windows.Forms.PictureBox();
            this.pictureBoxAllCheck = new System.Windows.Forms.PictureBox();
            this.panelFill.ClientArea.SuspendLayout();
            this.panelFill.SuspendLayout();
            this.panelContent.SuspendLayout();
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
            this.panelFill.Size = new System.Drawing.Size(171, 240);
            this.panelFill.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 78);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(169, 160);
            this.panelContent.TabIndex = 3;
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
            this.panelTop.Size = new System.Drawing.Size(169, 78);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(169, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxStartOpen
            // 
            this.pictureBoxStartOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxStartOpen.Image = global::AccelerateBall.Properties.Resources.开机加速;
            this.pictureBoxStartOpen.Location = new System.Drawing.Point(84, 0);
            this.pictureBoxStartOpen.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxStartOpen.Name = "pictureBoxStartOpen";
            this.pictureBoxStartOpen.Size = new System.Drawing.Size(85, 78);
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
            this.pictureBoxAllCheck.Size = new System.Drawing.Size(84, 78);
            this.pictureBoxAllCheck.TabIndex = 0;
            this.pictureBoxAllCheck.TabStop = false;
            this.pictureBoxAllCheck.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxAllCheck.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 240);
            this.Controls.Add(this.panelFill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenu";
            this.ShowInTaskbar = false;
            this.Text = "Form2";
            this.TopMost = true;
            this.MouseLeave += new System.EventHandler(this.FrmMenu_MouseLeave);
            this.panelFill.ClientArea.ResumeLayout(false);
            this.panelFill.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
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
    }
}