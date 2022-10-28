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
            bool isHd = false;

            var data = Convert.ToDateTime(date);
            string endpoint = $"{_apodEndpoint}?api_key={_apiKey}&hd={isHd.ToString().ToLower()}&date={data.ToString("yyyy-MM-dd")}";
            using (var client = new HttpClient(new HttpClientHandler()))
            {
                var result = client.GetAsync(endpoint);

                var resultToObject = result.Result.Content.ReadAsStringAsync();

                var deserialized = JsonConvert.DeserializeObject<NasaApod>(resultToObject.Result);

                if (deserialized != null && deserialized.media_type == MediaType.Video)
                {
                    return View("GetVideo", deserialized);

                }

                return View("GetPhoto", deserialized);
            }
        }
    }
}
