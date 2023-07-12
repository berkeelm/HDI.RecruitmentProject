using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebUI.Helpers
{
    public class RequestHelper
    {
        private static string serviceUrl = "https://localhost:7039/api";

        public static T SendRequest<T>(string _endpoint, object _data)
        {
            using (var client = new HttpClient())
            {
                var res = client.PostAsync(serviceUrl + _endpoint,
                  new StringContent(JsonConvert.SerializeObject(_data), Encoding.UTF8, "application/json")
                );


                var resylt = JsonConvert.DeserializeObject<T>(res.Result.Content.ReadAsStringAsync().Result);

                return resylt;

                try
                {
                    res.Result.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
