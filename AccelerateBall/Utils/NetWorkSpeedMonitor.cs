using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;

namespace AccelerateBall.Utils
{
    public class NetWorkSpeedMonitor
    {
        /// <summary>
        /// 实例
        /// </summary>
        private static NetWorkSpeedMonitor instance;

        private readonly string categoryName = "Network Interface";

        private readonly Timer timer;

        /// <summary>
        /// 当前选择的网卡
        /// </summary>
        public NetWorkAdapter Current { get; set; }

        /// <summary>
        /// 当前计算机上的所有网络适配器列表
        /// </summary>
        public List<NetWorkAdapter> Adapters { get; private set; }

        public NetWorkSpeedMonitor()
        {
            Adapters = new List<NetWorkAdapter>();
            EnumerateNetworkAdapters();

            timer = new Timer(850);
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
        }

        /// <summary>
        /// 列出当前计算机上的所有网络适配器
        /// </summary>
        private void EnumerateNetworkAdapters()
        {
            PerformanceCounterCategory category = new PerformanceCounterCategory(categoryName);

            foreach (string name in category.GetInstanceNames())
            {
                // 每一个计算机上都存在的网卡.
                if (name == "MS TCP Loopback interface" || name == "Teredo Tunneling Pseudo-Interface")
                    continue;
                var downCounter = new PerformanceCounter(categoryName, "Bytes Received/sec", name);
                var upCounter = new PerformanceCounter(categoryName, "Bytes Sent/sec", name);
                Adapters.Add(new NetWorkAdapter(name, downCounter, upCounter));
            }
        }

        /// <summary>
        /// 定时刷新网速
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var adapter in Adapters)
                adapter.Refresh();
        }

        /// <summary>
        /// 开启所有
        /// </summary>
        public void StartMonitoring()
        {
            if (Adapters.Count > 0)
            {
                foreach (var adapter in Adapters)
                    adapter.Init();

                timer.Enabled = true;
            }
        }

        /// <summary>
        /// 关闭所有
        /// </summary>
        public void StopMonitoring()
        {
            foreach (var item in Adapters)
            {
                item.Close();
            }
            Adapters.Clear();
            timer.Enabled = false;
        }

        public static NetWorkSpeedMonitor GetInstance()
        {
            if (instance == null)
            {
                instance = new NetWorkSpeedMonitor();
            }
            return instance;
        }
    }
}
