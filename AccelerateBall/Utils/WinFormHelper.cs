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
    }
}
