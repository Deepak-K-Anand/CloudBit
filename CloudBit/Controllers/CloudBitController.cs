using CloudBit.Utilities;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace CloudBit.Controllers
{
    public class CloudBitController : ApiController
    {
        [HttpGet]
        [Route("api/trigger")]
        public string Trigger([FromUri] Request req)
        {
            try
            {
                if (req != null && !req.AreParamsMissing())
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

                    return apiResponse.StatusCode == HttpStatusCode.OK ? "Yay! We turned it on. :-)" : ConfigurationManager.AppSettings[((int)apiResponse.StatusCode).ToString()];
                }
                else
                {
                    return "Looks like we didn't get everything to turn on the device :-(";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
