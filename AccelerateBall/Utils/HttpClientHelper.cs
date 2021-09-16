using AccelerateBall.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccelerateBall.Utils
{
    public class HttpClientHelper
    {
        private readonly static HttpClient Client = new HttpClient();

        public static async Task<List<Dict>> Get(List<string> codeList)
        {
            if (codeList.Count == 0) codeList.Add("sz002044");
            var baseUrl = $"http://hq.sinajs.cn/list={string.Join(",", codeList)}";
            var response = await Client.GetAsync(baseUrl);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var arr = responseBody.Split(';');
            var result = new List<Dict>();
            for (var i = 0; i < codeList.Count; i++)
            {
                var tempList = arr[i].Split(new char[] { ',', '=' });
                var name = tempList[1].Replace("\"", "");
                var now = double.Parse(tempList[4]);
                var pre = double.Parse(tempList[3]);
                var percentage = Math.Round(((now - pre) / pre) * 1000).ToString();
                result.Add(new Dict(codeList[i], name, now.ToString(), percentage));
            }
            return result;
        }

        public static void Close()
        {
            Client.Dispose();
        }
    }
}
