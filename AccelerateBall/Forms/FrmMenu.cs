using AccelerateBall.Model;
using AccelerateBall.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            var codeList = AppConfig.GetCodeList().Select(x => x.Code).ToList();
            for (var i = 1; i < codeList.Count; i++)
            {
                var panel = new Panel
                {
                    Name = codeList[i],
                    Dock = DockStyle.Top,
                    Height = 30,
                };

                var labelName = new Label
                {
                    Dock = DockStyle.Left,
                    Font = font,
                    Width = 65,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                var labelValue = new Label
                {
                    Dock = DockStyle.Fill,
                    Font = font,
                    TextAlign = ContentAlignment.MiddleRight
                };

                var labelRate = new Label
                {
                    Dock = DockStyle.Right,
                    Font = font,
                    Width = 42,
                    TextAlign = ContentAlignment.MiddleRight
                };

                panel.Controls.Add(labelName);
                panel.Controls.Add(labelValue);
                panel.Controls.Add(labelRate);
                panelContent.ClientArea.Controls.Add(panel);
            }
        }

        public void LoadData(List<Dict> list)
        {
            foreach (var control in panelContent.ClientArea.Controls)
            {
                if (control is Panel panel)
                {
                    var valueItem = list.Find(it => it.Code == panel.Name);
                    if (valueItem == null) continue;

                    panel.Controls[0].UpdateUI(() => panel.Controls[0].Text = valueItem.Name);

                    var color = valueItem.Percentage.StartsWith("-") ? Color.Green : Color.Red;

                    panel.Controls[1].UpdateUI(() =>
                    {
                        if (panel.Controls[1] is Label label)
                        {
                            label.ForeColor = color;
                            label.Text = valueItem.Value;
                        }
                    });

                    panel.Controls[2].UpdateUI(() =>
                    {
                        if (panel.Controls[2] is Label label)
                        {
                            label.ForeColor = color;
                            label.Text = valueItem.Percentage.TrimStart('-');
                        }
                    });
                }
            }
        }
    }
}