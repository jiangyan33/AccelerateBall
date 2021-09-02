using AccelerateBall.Utils;
using System;
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
            NLogHelper.Info("程序启动");
            Application.Run(new Forms.FrmMinBall());
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
            Application.Exit();
        }
    }
}
