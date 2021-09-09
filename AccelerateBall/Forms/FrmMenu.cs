using AccelerateBall.Model;
using AccelerateBall.Utils;
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
                var panel = new Panel
                {
                    Tag = codeList[i],
                    Dock = DockStyle.Top,
                    Height = 20
                };

                var labelName = new Label
                {
                    Dock = DockStyle.Fill,
                    Font = font
                };

                var labelValue = new Label
                {
                    Dock = DockStyle.Right,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = font
                };

                panel.Controls.Add(labelName);
                panel.Controls.Add(labelValue);

                flowLayoutPanel.Controls.Add(panel);
            }
        }

        public void LoadData(List<Dict> list)
        {
            foreach (var control in flowLayoutPanel.Controls)
            {
                if (control is Panel panel)
                {
                    var valueItem = list.Find(it => it.Code == panel.Tag.ToString());
                    if (valueItem != null)
                    {
                        panel.Controls[0].UpdateUI(() => panel.Controls[0].Text = valueItem.Name);

                        panel.Controls[1].UpdateUI(() =>
                        {
                            var label = (panel.Controls[1] as Label);
                            if (valueItem.Percentage.StartsWith("-"))
                            {
                                valueItem.Percentage = valueItem.Percentage.Replace("-", "");
                                label.ForeColor = Color.Green;
                            }
                            else
                            {
                                label.ForeColor = Color.Red;
                            }
                            Console.WriteLine(valueItem.Percentage);
                            panel.Controls[1].Text = valueItem.Percentage;

                        });
                    }
                }
            }
        }
    }
}