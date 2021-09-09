using System.Diagnostics;

namespace AccelerateBall.Utils
{
    /// <summary>
    /// 网络适配器
    /// </summary>
    public class NetWorkAdapter
    {
        /// <summary>
        /// 适配器的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 下载速度（kb/s）
        /// </summary>
        public double DownloadSpeed { get; set; }

        /// <summary>
        /// 上传速度（kb/s）
        /// </summary>
        public double UploadSpeed { get; set; }

        /// <summary>
        /// 下载计数器
        /// </summary>
        private readonly PerformanceCounter downCounter;

        /// <summary>
        /// 上传计数器
        /// </summary>
        private readonly PerformanceCounter upCounter;

        /// <summary>
        /// 当前性能计数器下载值
        /// </summary>
        private long downValue;

        /// <summary>
        /// 当前性能计数器上传值
        /// </summary>
        private long upValue;

        /// <summary>
        /// 前一段时间的性能计数器下载值
        /// </summary>
        private long downValueOld;

        /// <summary>
        /// 前一段时间的性能计数器上传值
        /// </summary>
        private long upValueOld;

        /// <summary>
        /// 网络适配器构造器
        /// </summary>
        /// <param name="name"></param>
        /// <param name="downCounter"></param>
        /// <param name="upCounter"></param>
        public NetWorkAdapter(string name, PerformanceCounter downCounter, PerformanceCounter upCounter)
        {
            Name = name;
            this.downCounter = downCounter;
            this.upCounter = upCounter;
        }

        /// <summary>
        /// 初始化旧的性能计数器值
        /// </summary>
        public void Init()
        {
            upValueOld = upCounter.NextSample().RawValue;
            downValueOld = downCounter.NextSample().RawValue;
        }

        /// <summary>
        /// 刷选性能计数器
        /// </summary>
        public void Refresh()
        {
            upValue = upCounter.NextSample().RawValue;
            downValue = downCounter.NextSample().RawValue;

            UploadSpeed = (upValue - upValueOld) / 1024.0;
            DownloadSpeed = (downValue - downValueOld) / 1024.0;

            upValueOld = upValue;
            downValueOld = downValue;
        }

        public void Close()
        {
            upCounter.Close();
            downCounter.Close();
        }
    }
}
