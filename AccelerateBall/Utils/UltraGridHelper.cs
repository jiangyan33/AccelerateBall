using Infragistics.Win;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AccelerateBall.Utils
{
    public class UltraGridHelper
    {
        public static void InitializeUltraGridDisplay(UltraGrid grid, List<UltraGridDisplayItem> displayItems, bool setDefaultStyle = false, UltraGridOptions ultraGridOptions = null)
        {
            if (setDefaultStyle) SetGridDefaultStyle(grid, ultraGridOptions);

            foreach (var item in grid.DisplayLayout.Bands)
            {
                InitializeUltraGridBandDisplay(item, displayItems);
            }
        }

        public static void InitializeUltraGridBandDisplay(UltraGridBand band, List<UltraGridDisplayItem> displayItems)
        {
            // 整理顺序，保证连续
            int index = 1;
            foreach (var item in displayItems.OrderBy(x => x.Position))
            {
                if (!band.Columns.Exists(item.Key))
                    continue;

                var col = band.Columns[item.Key];
                col.Hidden = item.Hidden;
                col.Header.Caption = item.Caption;
                col.Header.VisiblePosition = index++;
                // 设置表头高度
                col.RowLayoutColumnInfo.PreferredLabelSize = new Size(0, 40);
                if (item.Color != Color.Empty)
                    col.CellAppearance.ForeColor = item.Color;
            }

            // 保证显示顺序和不增加额外的事件触发的同时，将不显示的列隐藏
            foreach (var item in band.Columns)
            {
                if (!displayItems.Exists(x => x.Key.Equals(item.Key, StringComparison.OrdinalIgnoreCase)))
                    item.Hidden = true;
            }
        }

        private static void SetGridDefaultStyle(UltraGrid grid, UltraGridOptions ultraGridOptions)
        {
            if (ultraGridOptions == null) ultraGridOptions = new UltraGridOptions();

            // 可配置信息
            grid.DisplayLayout.Bands[0].Override.AllowUpdate = ultraGridOptions.AllowUpdate;
            grid.DisplayLayout.Override.RowSelectors = ultraGridOptions.RowSelectors;
            grid.DisplayLayout.Override.RowSelectorWidth = ultraGridOptions.RowSelectorWidth;
            if (ultraGridOptions.ShowSummary)
            {
                var band = grid.DisplayLayout.Bands[0];
                // 固定底部
                band.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed;
                band.Override.SummaryValueAppearance.BackColor = Color.White;
                band.Override.BorderStyleSummaryValue = UIElementBorderStyle.None;
                band.Override.SummaryFooterCaptionVisible = DefaultableBoolean.False;
                band.Override.SummaryValueAppearance.BorderColor = Color.Transparent;
                band.Override.SummaryFooterAppearance.BorderColor = Color.Transparent;
                if (band.Columns.Count > 0)
                {
                    var s1 = band.Summaries.Add(SummaryType.Count, band.Columns[0]);
                    s1.DisplayFormat = "总数 = {0}";
                    s1.SummaryPosition = SummaryPosition.Left;
                    s1.Appearance.FontData.Bold = DefaultableBoolean.True;
                    s1.Appearance.FontData.Name = "微软雅黑";
                    s1.Appearance.ForeColor = Color.SteelBlue;
                    s1.Appearance.TextVAlign = VAlign.Middle;
                    s1.Lines = ultraGridOptions.ShowSummaryLines;
                }
            }

            var colorBorder = Color.FromArgb(224, 224, 224);
            var colorBackground = Color.FromArgb(245, 245, 245);
            var colorForeground = Color.FromArgb(64, 64, 64);
            var colorWarning = Color.FromArgb(242, 149, 85);
            // 设置滚动条出现的时候不拆分
            grid.DisplayLayout.MaxColScrollRegions = 1;
            grid.DisplayLayout.MaxRowScrollRegions = 1;
            //grid.DisplayLayout.ScrollBarLook.VerticalScrollBarWidth = 50;
            //grid.DisplayLayout.ScrollBarLook.VerticalScrollBarArrowHeight = 70;
            //grid.DisplayLayout.ScrollBarLook.MinimumThumbHeight = 70;
            grid.DisplayLayout.Appearance.BackColor = Color.White;
            grid.DisplayLayout.BorderStyle = UIElementBorderStyle.None;
            grid.DisplayLayout.ScrollBounds = ScrollBounds.ScrollToFill;
            grid.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;
            grid.DisplayLayout.ViewStyle = ViewStyle.SingleBand;

            grid.DisplayLayout.DefaultSelectedBackColor = Color.Transparent;
            grid.DisplayLayout.DefaultSelectedForeColor = Color.Transparent;

            //grid.DisplayLayout.CaptionVisible = DefaultableBoolean.False;
            grid.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            grid.DisplayLayout.NoDataSourceMessageEnabled = DefaultableBoolean.True;
            grid.DisplayLayout.NoDataSourceMessageAppearance.ForeColor = colorWarning;
            grid.DisplayLayout.NoDataSourceMessageAppearance.TextHAlign = HAlign.Center;
            grid.DisplayLayout.NoDataSourceMessageAppearance.TextVAlign = VAlign.Middle;

            grid.DisplayLayout.Override.RowAppearance.BorderColor = colorBorder;
            grid.DisplayLayout.Override.CellAppearance.BorderColor = Color.Transparent;
            grid.DisplayLayout.Override.CellPadding = 0;
            grid.DisplayLayout.Override.DefaultRowHeight = 48;

            grid.DisplayLayout.Override.HeaderStyle = HeaderStyle.Standard;
            grid.DisplayLayout.Override.HeaderAppearance.BackColor = colorBackground;
            grid.DisplayLayout.Override.HeaderAppearance.ForeColor = colorForeground;
            grid.DisplayLayout.Override.HeaderAppearance.TextHAlign = HAlign.Center;
            grid.DisplayLayout.Override.HeaderAppearance.TextVAlign = VAlign.Middle;
            grid.DisplayLayout.Override.HeaderClickAction = ultraGridOptions.HeaderClickAction;

            grid.DisplayLayout.Override.RowSelectorStyle = HeaderStyle.Standard;
            grid.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.Transparent;
            grid.DisplayLayout.Override.RowSelectorAppearance.ForeColor = colorForeground;
            grid.DisplayLayout.Override.RowSelectorAppearance.TextHAlign = HAlign.Center;
            grid.DisplayLayout.Override.RowSelectorAppearance.TextVAlign = VAlign.Middle;
            grid.DisplayLayout.Override.RowSelectorAppearance.BorderColor = colorBorder;
            grid.DisplayLayout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.VisibleIndex;
            grid.DisplayLayout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;

            grid.DisplayLayout.Override.SelectTypeGroupByRow = SelectType.None;
            grid.DisplayLayout.Override.SelectTypeRow = SelectType.None;

            grid.DisplayLayout.Override.BorderStyleRow = UIElementBorderStyle.None;
            grid.DisplayLayout.Override.BorderStyleRowSelector = UIElementBorderStyle.None;
            grid.DisplayLayout.Override.BorderStyleHeader = UIElementBorderStyle.None;
            grid.DisplayLayout.Override.BorderStyleCell = UIElementBorderStyle.None;

            grid.DisplayLayout.Override.ActiveAppearancesEnabled = DefaultableBoolean.False;
            grid.DisplayLayout.Override.ActiveRowAppearance.BackColor = colorBackground;
            grid.DisplayLayout.Override.ActiveRowAppearance.ForeColor = colorForeground;

            grid.DisplayLayout.Override.SelectedAppearancesEnabled = DefaultableBoolean.True;
            grid.DisplayLayout.Override.SelectedCellAppearance.BackColor = colorBackground;
            grid.DisplayLayout.Override.SelectedCellAppearance.ForeColor = colorForeground;

            grid.DisplayLayout.Override.CellAppearance.BorderColor = colorBackground;
            grid.DisplayLayout.Override.CellAppearance.TextTrimming = TextTrimming.EllipsisCharacter;
            grid.DisplayLayout.Override.CellAppearance.TextHAlign = HAlign.Center;
            grid.DisplayLayout.Override.CellAppearance.TextVAlign = VAlign.Middle;
            grid.DisplayLayout.Override.CellClickAction = CellClickAction.RowSelect;

            grid.DisplayLayout.Override.AllowColSizing = AllowColSizing.None;

            grid.DisplayLayout.RowSelectorImages.DataChangedImage = null;
            foreach (var item in grid.DisplayLayout.Bands)
            {
                SetGridBandDefaultStyle(item);
            }
        }

        private static void SetGridBandDefaultStyle(UltraGridBand band)
        {
            var colorWarning = Color.FromArgb(242, 149, 85);
            // 调整默认行高信息
            band.Override.DefaultRowHeight = 40;
            band.Override.RowSizing = RowSizing.Fixed;
            band.Override.NoRowsInDataSourceMessageAppearance.ForeColor = colorWarning;
            band.Override.NoRowsInDataSourceMessageAppearance.TextHAlign = HAlign.Center;
            band.Override.NoRowsInDataSourceMessageAppearance.TextVAlign = VAlign.Middle;

            band.Override.NoRowsInDataSourceMessageEnabled = DefaultableBoolean.True;
            band.Override.NoRowsInDataSourceMessageText = "没有找到任何数据";

            band.Override.NoVisibleRowsMessageAppearance.ForeColor = colorWarning;
            band.Override.NoVisibleRowsMessageAppearance.TextHAlign = HAlign.Center;
            band.Override.NoVisibleRowsMessageAppearance.TextVAlign = VAlign.Middle;
            band.Override.NoVisibleRowsMessageEnabled = DefaultableBoolean.True;
            band.Override.NoVisibleRowsMessageText = "没有匹配到任何记录";

            band.RowLayoutStyle = RowLayoutStyle.ColumnLayout;
        }

        /// <summary>
        /// 此方法在 <see cref="UltraGrid" /> 的 InitializeRow 事件下调用
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="caption">列标题</param>
        /// <param name="displayItems">要添加的按钮</param>
        /// <param name="row">InitializeRow事件的参数e</param>
        /// <param name="linkedColumn">添加的超链接列</param>
        /// <param name="clickAction">点击链接后的事件处理</param>
        public static UltraGridColumn AddLinkedColumn(UltraGrid grid,
            string caption,
            List<UltraGridDisplayItem> displayItems,
            LinkClickedEventHandler clickAction,
            Action<UltraGridColumn> linkedColumn = null)
        {
            if (!grid.DisplayLayout.Bands[0].Columns.Exists(caption))
            {
                UltraGridColumn col = grid.DisplayLayout.Bands[0].Columns.Add(caption);
                var linkLable = new UltraFormattedLinkLabel
                {
                    UnderlineLinks = UnderlineLink.Never
                };
                // 设置点击前后样式一样
                linkLable.LinkAppearance.ForeColor = Color.Blue;
                linkLable.VisitedLinkAppearance.ForeColor = Color.Blue;
                linkLable.HotTrackLinkAppearance.ForeColor = Color.Blue;
                linkLable.LinkClicked += (s, e) =>
                {
                    // 不打开超链接
                    e.OpenLink = false;
                    clickAction.Invoke(s, e);
                };
                col.EditorComponent = linkLable;
                col.CellClickAction = CellClickAction.RowSelect;
                col.CellActivation = Activation.ActivateOnly;
                col.AutoEditMode = DefaultableBoolean.False;
                col.Width = 140;
                col.AllowRowFiltering = DefaultableBoolean.False;
                col.AllowGroupBy = DefaultableBoolean.False;
                col.AllowRowSummaries = AllowRowSummaries.False;
                col.Header.Appearance.TextHAlign = HAlign.Center;
                col.Header.Appearance.TextVAlign = VAlign.Middle;
                col.CellAppearance.TextHAlign = HAlign.Center;
                col.CellAppearance.TextVAlign = VAlign.Middle;
                col.CellAppearance.ForeColor = Color.White;
                col.Header.Fixed = true;
                col.Header.VisiblePosition = 1000;
                col.Header.FixOnRight = DefaultableBoolean.True;
                linkedColumn?.Invoke(col);
                List<string> content = new List<string>();
                foreach (var item in displayItems)
                {
                    content.Add($@"<a style='display:block;fore-color:#379bce;text-align:center' href='{item.Key}'>{item.Caption}</a>");
                }
                // 循环赋值单元格value属性
                foreach (var row in grid.Rows)
                {
                    row.Cells[caption].Value = string.Join(" ", content.ToArray());
                }
                return col;
            }

            return grid.DisplayLayout.Bands[0].Columns[caption];
        }

        /// <summary>
        /// 动态添加列 使用此方法初始化列后，需要给该列赋值时，需要配合InitializeRow事件来做赋值
        /// </summary>
        /// <param name="band">band</param>
        /// <param name="key">key</param>
        /// <param name="caption">列标题</param>
        /// <param name="type">列类型</param>
        /// <param name="color">颜色</param>
        /// <param name="hAlign">水平对齐方式</param>
        /// <param name="vAlign">垂直对齐方式</param>
        /// <returns></returns>
        public static UltraGridColumn AddUnBoundColumn(UltraGrid grid,
               string key,
               string caption,
               ColumnStyle type,
               Color color,
               string defaultValue = "",
               HAlign hAlign = HAlign.Center,
               VAlign vAlign = VAlign.Middle
               )
        {
            if (grid.DisplayLayout.Bands[0].Columns.Cast<UltraGridColumn>().Count(c => c.Key == key) > 0)
                return grid.DisplayLayout.Bands[0].Columns[key];
            var col = grid.DisplayLayout.Bands[0].Columns.Add(key, caption);
            col.Style = type;
            //col.NullText = defaultValue;
            col.CellClickAction = CellClickAction.RowSelect;
            col.CellAppearance.TextHAlign = hAlign;
            col.CellAppearance.TextVAlign = vAlign;
            col.CellAppearance.ForeColor = color;
            col.Header.Appearance.TextHAlign = hAlign;
            col.Header.Appearance.TextVAlign = vAlign;
            // 针对NullText属性不生效的处理情况
            if (!string.IsNullOrEmpty(caption))
            {
                foreach (var item in grid.Rows)
                    item.Cells[key].Value = defaultValue;
            }
            return col;
        }
    }

    public class DisplayItem
    {
        public string Key { get; set; }

        public string Caption { get; set; }

        public int Position { get; set; }

        public override string ToString()
        {
            return Caption;
        }
    }

    public class DisplayItemComparer : IEqualityComparer<DisplayItem>
    {
        public bool Equals(DisplayItem x, DisplayItem y)
        {
            return string.Compare(x.Key, y.Key, true) == 0;
        }

        public int GetHashCode(DisplayItem obj)
        {
            return obj.Key.GetHashCode();
        }
    }

    /// <summary>
    /// 自定义列表集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DisplayItemCollection<T> : DisplayItem
    {
        public List<T> List { get; set; }
    }

    public class UltraGridDisplayItem : DisplayItem
    {
        /// <summary>
        /// 列颜色,空值为默认
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 列样式,空值为默认
        /// </summary>
        public ColumnStyle ColumnStyle { get; set; }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        public bool Hidden { get; set; }

        public int ColumnWidth { get; set; }
    }

    public class UltraGridOptions
    {
        /// <summary>
        /// 是否显示列序号
        /// </summary>
        public DefaultableBoolean RowSelectors { get; set; } = DefaultableBoolean.False;

        /// <summary>
        /// 列序号宽度
        /// </summary>
        public int RowSelectorWidth { get; set; } = 0;

        /// <summary>
        /// 是否允许更新grid
        /// </summary>
        public DefaultableBoolean AllowUpdate { get; set; } = DefaultableBoolean.False;

        /// <summary>
        /// 是否显示概要
        /// </summary>
        public bool ShowSummary { get; set; }

        /// <summary>
        /// 概要占的行数
        /// </summary>
        public int ShowSummaryLines { get; set; } = 1;

        /// <summary>
        /// 点击表头是否可以排序
        /// </summary>
        public HeaderClickAction HeaderClickAction { get; set; } = HeaderClickAction.SortSingle;
    }
}
