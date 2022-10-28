using APOD.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace APOD.Controllers
{
    public class ApodController : Controller
    {
        private string _apiKey = "Xfwoi46lbj0tkkjmDrGt0f9uappcLhMjQhwDk0Mf";
        private string _apodEndpoint = "https://api.nasa.gov/planetary/apod";
        
        
       //https://localhost:7129/APOD/Get
        [HttpPost]
        public IActionResult Get(string date)
        {
            string endpoint = string.Empty;
            bool isHD = false;

            var data = Convert.ToDateTime(date);
            endpoint = $"{this._apodEndpoint}?api_key={this._apiKey}&hd={isHD.ToString().ToLower()}&Date={data.ToString("yyyy-MM-dd")}";
            using (var client = new HttpClient(new System.Net.Http.HttpClientHandler()))
            {
                var result = client.GetAsync(endpoint);

                var resultToObject = result.Result.Content.ReadAsStringAsync();

                var deserialized = JsonConvert.DeserializeObject<NasaApod>(resultToObject.Result.ToString());
                if (deserialized.MediaType.Equals("video"))
                {
                    return View("GetVideo", deserialized);

                }

                return View("GetPhoto", deserialized);
            }
        }
    }
}
