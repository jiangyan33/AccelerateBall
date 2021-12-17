using AccelerateBall.Forms;
using AccelerateBall.Utils;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace AccelerateBall
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //处理未捕获的异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //处理非线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Process instance = RunningInstance();
            if (instance == null)
            {
                NLogHelper.Info("程序启动");
                Application.Run(new FrmMinBall());
            }
            else
            {
                NLogHelper.Info("已经存在正在运行的实例");
                HandleRunningInstance(instance);
            }

        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            NLogHelper.Error($"发现未能捕获的异常.{(e.ExceptionObject as Exception).Message}\r\n{e.ExceptionObject}");
            Exit();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            NLogHelper.Error($"捕获线程异常.{e.Exception.Message}\r\n{e.Exception.StackTrace}");
            Exit();
        }

        public static void Exit()
        {
            NLogHelper.Info("程序退出");
            HttpClientHelper.Close();
            NetWorkSpeedMonitor.GetInstance().StopMonitoring();
            Application.Exit();
        }

        /// <summary>
        /// 获取正在运行的实例，没有运行的实例返回null;
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id && process.MainModule.FileName == current.MainModule.FileName)
                {
                    return process;
                }
            }
            return null;
        }

        /// <summary>
        /// 显示已运行的程序。
        /// </summary>
        public static void HandleRunningInstance(Process instance)
        {
            User32.ShowWindowAsync(instance.MainWindowHandle, User32.WS_SHOWMAXIMIZE); //显示，通过后面的值可以对窗口大小进行控制
            User32.SetForegroundWindow(instance.MainWindowHandle);            //放到前端
        }
    }
}
