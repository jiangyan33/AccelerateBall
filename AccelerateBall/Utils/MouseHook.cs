using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AccelerateBall.Utils
{
    /// <summary>
    /// 全局鼠标事件监控
    /// </summary>
    public class MouseHook
    {
        private const int WM_MOUSEMOVE = 0x200;
        private const int WM_LBUTTONDOWN = 0x201;
        private const int WM_RBUTTONDOWN = 0x204;
        private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_LBUTTONUP = 0x202;
        private const int WM_RBUTTONUP = 0x205;
        private const int WM_MBUTTONUP = 0x208;
        private const int WM_LBUTTONDBLCLK = 0x203;
        private const int WM_RBUTTONDBLCLK = 0x206;
        private const int WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// 全局鼠标移动事件
        /// </summary>
        //public event MouseEventHandler OnMouseActivity;

        /// <summary>
        /// 全局鼠标点击事件
        /// </summary>
        public event MouseEventHandler OnMouseClickEvent;

        static int hMouseHook = 0; //鼠标钩子句柄    

        //鼠标常量    
        public const int WH_MOUSE_LL = 14; //mouse hook constant    

        HookProc MouseHookProcedure; //声明鼠标钩子事件类型.    

        //声明一个Point的封送类型    
        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        //声明鼠标钩子的封送结构类型    
        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hWnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        //装置钩子的函数    
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        //卸下钩子的函数    
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        //下一个钩挂的函数    
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);

        public delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        /// <summary>    
        /// 墨认的构造函数构造当前类的实例.    
        /// </summary>    
        public MouseHook()
        {
        }

        //析构函数.    
        ~MouseHook()
        {
            Stop();
        }

        public void Start()
        {
            //安装鼠标钩子    
            if (hMouseHook == 0)
            {
                //生成一个HookProc的实例.    
                MouseHookProcedure = new HookProc(MouseHookProc);
                using (System.Diagnostics.Process curProcess = System.Diagnostics.Process.GetCurrentProcess())
                using (System.Diagnostics.ProcessModule curModule = curProcess.MainModule)
                    hMouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseHookProcedure, GetModuleHandle(curModule.ModuleName), 0);

                //如果装置失败停止钩子    
                if (hMouseHook == 0)
                {
                    Stop();
                    throw new Exception("SetWindowsHookEx failed.");
                }
            }
        }

        public void Stop()
        {
            bool retMouse = true;
            if (hMouseHook != 0)
            {
                retMouse = UnhookWindowsHookEx(hMouseHook);
                hMouseHook = 0;
            }

            //如果卸下钩子失败    
            if (!(retMouse)) throw new Exception("UnhookWindowsHookEx failed.");
        }

        private int MouseHookProc(int nCode, Int32 wParam, IntPtr lParam)
        {
            //如果正常运行并且用户要监听鼠标的消息    
            //if ((nCode >= 0) && (OnMouseActivity != null))
            //{
            //    MouseButtons button = MouseButtons.None;
            //    int clickCount = 0;

            //    switch (wParam)
            //    {
            //        case WM_LBUTTONDOWN:
            //            button = MouseButtons.Left;
            //            clickCount = 1;
            //            break;
            //        case WM_LBUTTONUP:
            //            button = MouseButtons.Left;
            //            clickCount = 1;
            //            break;
            //        case WM_LBUTTONDBLCLK:
            //            button = MouseButtons.Left;
            //            clickCount = 2;
            //            break;
            //        case WM_RBUTTONDOWN:
            //            button = MouseButtons.Right;
            //            clickCount = 1;
            //            break;
            //        case WM_RBUTTONUP:
            //            button = MouseButtons.Right;
            //            clickCount = 1;
            //            break;
            //        case WM_RBUTTONDBLCLK:
            //            button = MouseButtons.Right;
            //            clickCount = 2;
            //            break;
            //    }

            //    //从回调函数中得到鼠标的信息    
            //    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
            //    MouseEventArgs e = new MouseEventArgs(button, clickCount, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);

            //    OnMouseActivity(this, e);
            //}

            if (nCode >= 0 && OnMouseClickEvent != null)
            {
                MouseButtons button = MouseButtons.None;
                int clickCount = 0;
                switch (wParam)
                {
                    case WM_LBUTTONDOWN:
                        button = MouseButtons.Left;
                        clickCount = 1;
                        break;
                    //case WM_LBUTTONUP:
                    //    button = MouseButtons.Left;
                    //    clickCount = 1;
                    //    break;
                    case WM_LBUTTONDBLCLK:
                        button = MouseButtons.Left;
                        clickCount = 2;
                        break;
                    case WM_RBUTTONDOWN:
                        button = MouseButtons.Right;
                        clickCount = 1;
                        break;
                    //case WM_RBUTTONUP:
                    //    button = MouseButtons.Right;
                    //    clickCount = 1;
                    //    break;
                    case WM_RBUTTONDBLCLK:
                        button = MouseButtons.Right;
                        clickCount = 2;
                        break;
                }
                if (button != MouseButtons.None)
                {
                    MouseHookStruct MyMouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                    MouseEventArgs e = new MouseEventArgs(button, clickCount, MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y, 0);
                    OnMouseClickEvent(this, e);
                }
            }
            return CallNextHookEx(hMouseHook, nCode, wParam, lParam);
        }
    }
}
