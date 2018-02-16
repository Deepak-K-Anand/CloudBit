using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using CloudBit.Utilities;
using Newtonsoft.Json;

namespace CloudBit.Controllers
{
    public class CloudBitController : ApiController
    {
        [System.Web.Http.Route("api/trigger")]
        [System.Web.Http.HttpGet]
        public string Trigger([FromUri] Request req)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["CloudBitAPI"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.littlebits.master+json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", req.Key);

                var body = new StringContent(JsonConvert.SerializeObject(new DeviceOutput(req.Strength, req.Duration)), Encoding.UTF8, "application/json");

                HttpResponseMessage apiResponse = client.PostAsync(
                    "/v2/devices/" + req.DeviceId + "/output",
                    body
                ).Result;

                return apiResponse.StatusCode.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
