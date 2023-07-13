using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebUI.Interfaces;

namespace WebUI.Helpers
{
    public class RequestHelper : IRequestHelper
    {
        private readonly string serviceUrl = "https://localhost:7039/api";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RequestHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T SendRequest<T>(string _endpoint, object _data)
        {
            using (var client = new HttpClient())
            {
                string token = _httpContextAccessor.HttpContext.Request.Cookies["auth_token"];

                if (token != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var res = client.PostAsync(serviceUrl + _endpoint,
                  new StringContent(JsonConvert.SerializeObject(_data), Encoding.UTF8, "application/json")
                );


                var result = JsonConvert.DeserializeObject<T>(res.Result.Content.ReadAsStringAsync().Result);

                return result;
            }
        }
    }
}
