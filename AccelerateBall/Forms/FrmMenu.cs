using AccelerateBall.Model;
using AccelerateBall.Utils;
using Infragistics.Win.Misc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AccelerateBall.Forms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            LoadPanel();
        }
        private void FrmMenu_MouseLeave(object sender, EventArgs e) => Hide();

        private void PictureBox_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            if (sender is PictureBox pic)
            {
                if (pic.Name == pictureBoxAllCheck.Name)
                {
                    pic.Image = Properties.Resources.全面体检选中;
                }
                else if (pic.Name == pictureBoxStartOpen.Name)
                {
                    pic.Image = Properties.Resources.开机加速选中;
                }
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            if (sender is PictureBox pic)
            {
                if (pic.Name == pictureBoxAllCheck.Name)
                {
                    pic.Image = Properties.Resources.全面体检;
                }
                else if (pic.Name == pictureBoxStartOpen.Name)
                {
                    pic.Image = Properties.Resources.开机加速;
                }
            }
        }

        private void LoadPanel()
        {
            var font = new Font(new FontFamily("微软雅黑"), 10, FontStyle.Bold);
            var codeList = AppConfig.CodeList;
            for (var i = 1; i < codeList.Count; i++)
            {
                var panel = new UltraPanel
                {
                    Tag = codeList[i],
                    Dock = DockStyle.Top,
                    Height = 30,
                };

                var labelName = new UltraLabel
                {
                    Dock = DockStyle.Left,
                    Font = font,
                    AutoSize = true
                };
                labelName.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                labelName.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                var labelValue = new UltraLabel
                {
                    Dock = DockStyle.Fill,
                    Font = font,
                };
                labelValue.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                labelValue.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                var labelRate = new UltraLabel
                {
                    Dock = DockStyle.Right,
                    Font = font,
                    Width = 42,
                    Margin = new Padding(0, 0, 0, 2)
                };
                labelRate.Appearance.TextHAlign = Infragistics.Win.HAlign.Right;
                labelRate.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;

                panel.ClientArea.Controls.Add(labelName);
                panel.ClientArea.Controls.Add(labelValue);
                panel.ClientArea.Controls.Add(labelRate);
                panelContent.ClientArea.Controls.Add(panel);
            }
        }

        public void LoadData(List<Dict> list)
        {
            foreach (var control in panelContent.ClientArea.Controls)
            {
                if (control is UltraPanel panel)
                {
                    var valueItem = list.Find(it => it.Code == panel.Tag.ToString());
                    if (valueItem != null)
                    {
                        panel.ClientArea.Controls[0].UpdateUI(() => panel.ClientArea.Controls[0].Text = valueItem.Name);

                        var color = valueItem.Percentage.StartsWith("-") ? Color.Green : Color.Pink;

                        panel.ClientArea.Controls[1].UpdateUI(() =>
                        {
                            var label = (panel.ClientArea.Controls[1] as UltraLabel);
                            label.Appearance.ForeColor = color;
                            label.Text = valueItem.Value;
                        });

                        panel.ClientArea.Controls[2].UpdateUI(() =>
                        {
                            var label = (panel.ClientArea.Controls[2] as UltraLabel);
                            label.Appearance.ForeColor = color;
                            label.Text = valueItem.Percentage.TrimStart('-');
                        });
                    }
                }
            }
        }
    }
}