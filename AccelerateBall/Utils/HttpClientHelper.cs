using AccelerateBall.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AccelerateBall.Utils
{
    public class HttpClientHelper
    {
        private readonly static HttpClient Client = new HttpClient();

        public static async Task<List<Dict>> Get()
        {
            var dictList = AppConfig.GetCodeList();
            var codeList = dictList.Select(x => x.Code).ToList();
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
                var dict = dictList.Find(x => x.Code == codeList[i]);
                if (!string.IsNullOrEmpty(dict.Name)) name = dict.Name;
                var now = Math.Round(decimal.Parse(tempList[4]), 2);
                var pre = decimal.Parse(tempList[3]);
                int percentage = (int)Math.Round(((now - pre) / pre) * 1000);
                if (now > 1000)
                {
                    now = Math.Round(now);
                }
                else if (now > 100)
                {
                    now = Math.Round(now, 1);
                }
                result.Add(new Dict(codeList[i], name, now, percentage));
            }
            return result;
        }

        public static void Close()
        {
            Client.Dispose();
        }
    }
}
