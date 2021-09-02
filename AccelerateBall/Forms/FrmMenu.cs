using System;
using System.Windows.Forms;

namespace AccelerateBall.Forms
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
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
    }
}