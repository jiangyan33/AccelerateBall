using System;
using System.Diagnostics;

namespace AccelerateBall.Utils
{
    public class NLogHelper
    {
        private static readonly string CurrFullClassName = "AccelerateBall.Utils.NLogHelper";

        private static NLog.ILogger Logger => NLog.LogManager.GetLogger(GetClassName());

        /// <summary>
        /// 获取距离调用日志最近的类名
        /// </summary>
        /// <returns></returns>
        private static string GetClassName()
        {
            try
            {
                var st = new StackTrace();

                for (int i = 0; i < st.FrameCount; i++)
                {
                    if (!st.GetFrame(i).GetMethod().DeclaringType.FullName.Equals(CurrFullClassName))
                    {
                        var method = st.GetFrame(i).GetMethod();
                        return method.DeclaringType.FullName;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return CurrFullClassName;
        }

        public static void Trace(object value) => Logger.Trace(value);

        public static void Trace(string message, object argument) => Logger.Trace(message, argument);

        public static void Trace<T>(T value) => Logger.Trace(value);

        public static void Trace(Exception exception, string message) => Logger.Trace(exception, message);

        public static void Trace(Exception exception, string message, params object[] args) => Logger.Trace(exception, message, args);

        public static void Trace(string message) => Logger.Trace(message);

        public static void Trace(string message, params object[] args) => Logger.Trace(message, args);

        public static void Debug(object value) => Logger.Debug(value);

        public static void Debug(string message, object argument) => Logger.Debug(message, argument);

        public static void Debug<T>(T value) => Logger.Debug(value);

        public static void Debug(Exception exception, string message) => Logger.Debug(exception, message);

        public static void Debug(Exception exception, string message, params object[] args) => Logger.Debug(exception, message, args);

        public static void Debug(string message) => Logger.Debug(message);

        public static void Debug(string message, params object[] args) => Logger.Debug(message, args);

        public static void Info(object value) => Logger.Info(value);

        public static void Info(string message, object argument) => Logger.Info(message, argument);

        public static void Info<T>(T value) => Logger.Info(value);

        public static void Info(Exception exception, string message) => Logger.Info(exception, message);

        public static void Info(Exception exception, string message, params object[] args) => Logger.Info(exception, message, args);

        public static void Info(string message) => Logger.Info(message);

        public static void Info(string message, params object[] args) => Logger.Info(message, args);

        public static void Warn(object value) => Logger.Warn(value);

        public static void Warn(string message, object argument) => Logger.Warn(message, argument);

        public static void Warn<T>(T value) => Logger.Warn(value);

        public static void Warn(Exception exception, string message) => Logger.Warn(exception, message);

        public static void Warn(Exception exception, string message, params object[] args) => Logger.Warn(exception, message, args);

        public static void Warn(string message) => Logger.Warn(message);

        public static void Warn(string message, params object[] args) => Logger.Warn(message, args);

        public static void Error(object value) => Logger.Error(value);

        public static void Error(string message, object argument) => Logger.Error(message, argument);

        public static void Error<T>(T value) => Logger.Error(value);

        public static void Error(Exception exception, string message) => Logger.Error(exception, message);

        public static void Error(Exception exception, string message, params object[] args) => Logger.Error(exception, message, args);

        public static void Error(string message) => Logger.Error(message);

        public static void Error(string message, params object[] args) => Logger.Error(message, args);

        public static void Fatal(object value) => Logger.Fatal(value);

        public static void Fatal(string message, object argument) => Logger.Fatal(message, argument);

        public static void Fatal<T>(T value) => Logger.Fatal(value);

        public static void Fatal(Exception exception, string message) => Logger.Fatal(exception, message);

        public static void Fatal(Exception exception, string message, params object[] args) => Logger.Fatal(exception, message, args);

        public static void Fatal(string message) => Logger.Fatal(message);

        public static void Fatal(string message, params object[] args) => Logger.Fatal(message, args);
    }
}
