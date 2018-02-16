using CloudBit.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace CloudBit.Controllers
{
    public class CloudBitController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/trigger")]
        public string Trigger([FromUri] Request req)
        {
            try
            {
                if (!req.AreParamsMissing())
                {
                    //Build the Request
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["CloudBitAPIHost"]);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", req.Key);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.littlebits.master+json"));

                    //Construct the Body
                    var body = new StringContent(JsonConvert.SerializeObject(new DeviceOutput(req.Strength, req.Duration)), Encoding.UTF8, "application/json");

                    //Send the Request
                    HttpResponseMessage apiResponse = client.PostAsync(
                        String.Format(ConfigurationManager.AppSettings["CloudBitAPIOutput"], req.DeviceId),
                        body
                    ).Result;

                    return apiResponse.StatusCode.ToString();
                }
                else
                {
                    return "Missing Parameters!";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
