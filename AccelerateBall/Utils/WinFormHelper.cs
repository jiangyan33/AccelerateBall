using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace AccelerateBall.Utils
{
    public static class WinFormHelper
    {
        public static void UpdateUI(this Control control, MethodInvoker methodInvoker)
        {
            if (control.InvokeRequired)
            {
                try
                {
                    if (!control.Disposing && !control.IsDisposed)
                    {
                        control.Invoke(methodInvoker);
                    }
                }
                catch (ThreadAbortException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (InvalidAsynchronousStateException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                try
                {
                    methodInvoker();
                }
                catch (ThreadAbortException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void FormHideOrShow(Form form, ref int formHeight)
        {
            // 控件的位置
            int top = 0, left = 0, height = form.Height;
            bool changeLocation = true;
            if (form.WindowState == FormWindowState.Minimized || !form.Visible) return;
            // (鼠标的X坐标>窗体左上角X坐标-1)&&(鼠标的X坐标<窗体右上角X坐标)&&（鼠标的Y坐标>窗体右上角Y坐标-1）&&(鼠标的Y坐标<窗体右下角Y坐标)
            // 当前鼠标的光标在窗体内部（光标拖动窗体移动的时候，始终让窗体在屏幕中间）
            if (Cursor.Position.X > form.Left - 1 && Cursor.Position.X < form.Right && Cursor.Position.Y > form.Top - 1 && Cursor.Position.Y < form.Bottom)
            {
                // （窗体左上角Y坐标<=0&&窗体左上角X坐标>5）
                if (form.Top <= 0 && form.Left > 5 && form.Left < Screen.PrimaryScreen.WorkingArea.Width - form.Width)
                {
                    // 在屏幕上方且不在左也不在右
                    // top = 0;
                }
                else if (form.Left <= 0)
                {
                    // 在屏幕左侧
                    // left = 0;
                }
                else if (form.Left + form.Width >= Screen.PrimaryScreen.WorkingArea.Width)
                {
                    // 在屏幕右侧
                    left = Screen.PrimaryScreen.WorkingArea.Width - form.Width;
                }
                else
                {
                    // 正常显示，在屏幕中间
                    if (formHeight > 0)
                    {
                        height = formHeight;
                        formHeight = 0;
                        changeLocation = false;
                    }
                }
            }
            else
            {
                if (formHeight < 1)
                {
                    formHeight = form.Height;
                }
                if (form.Left + form.Width >= Screen.PrimaryScreen.WorkingArea.Width - 4)
                {
                    // 右侧隐藏
                    left = Screen.PrimaryScreen.WorkingArea.Width - 3;
                }
            }

            form.UpdateUI(() =>
            {
                if (changeLocation && form.Left != left) form.Left = left;

                if (changeLocation && form.Top != top) form.Top = top;

                if (form.Height != height) form.Height = height;
            });
        }
    }
}
