using AccelerateBall.Model;
using AccelerateBall.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            LoadGrid();
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

        private void LoadGrid()
        {
            grid.UpdateUI(() =>
            {
                if (grid.DataSource == null)
                {
                    var codeList = AppConfig.GetCodeList();

                    grid.DataSource = new BindingList<Dict>(codeList);
                    var items = new List<UltraGridDisplayItem>()
                    {
                        new UltraGridDisplayItem{  Key ="Name", Caption="名称", Position=1},
                        new UltraGridDisplayItem{  Key ="Value", Caption="价格", Position=2},
                        new UltraGridDisplayItem{  Key ="Percentage", Caption="涨幅", Position=3},
                    };
                    UltraGridHelper.InitializeUltraGridDisplay(grid, items, true);
                    var columns = grid.DisplayLayout.Bands[0].Columns;

                    columns["Name"].Width = 76;
                    columns["Value"].Width = 56;
                    columns["Percentage"].Width = 40;
                }
            });
        }

        public void LoadData(List<Dict> list)
        {
            foreach (var row in grid.Rows)
            {
                var rowItem = row.ListObject as Dict;
                var newItem = list.First(x => x.Code == rowItem.Code);

                if (rowItem.Name != newItem.Name) rowItem.Name = newItem.Name;
                rowItem.Value = newItem.Value;

                var color = Color.Red;
                if (newItem.FormartPercentage.StartsWith("-"))
                {
                    color = Color.Green;
                }
                rowItem.FormartPercentage = newItem.FormartPercentage;
                if (row.Cells[nameof(Dict.Value)].Appearance.ForeColor != color)
                {
                    row.Cells[nameof(Dict.FormartPercentage)].Appearance.ForeColor = color;
                    row.Cells[nameof(Dict.Value)].Appearance.ForeColor = color;
                }
            }
        }
    }
}