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
            uiSwitch.Active = AppConfig.TopMost;
            LoadGrid();
        }

        public event EventHandler CheckedChanged;

        private void FrmMenu_MouseLeave(object sender, EventArgs e) => Hide();

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
                    columns["Percentage"].FormatInfo = new FormartInfo();
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
                rowItem.Percentage = newItem.Percentage;
                var color = newItem.Percentage < 0 ? Color.Green : Color.Red;
                if (row.Cells[nameof(Dict.Value)].Appearance.ForeColor != color)
                {
                    row.Cells[nameof(Dict.Percentage)].Appearance.ForeColor = color;
                    row.Cells[nameof(Dict.Value)].Appearance.ForeColor = color;
                }
            }
        }

        private class FormartInfo : IFormatProvider
        {
            public object GetFormat(Type formatType) => "{0:0;0;0}";
        }

        private void uiSwitch_ValueChanged(object sender, bool value) => CheckedChanged?.Invoke(value, null);

    }
}