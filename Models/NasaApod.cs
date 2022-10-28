namespace APOD.Models
{
    public class NasaApod
    {
        public string Copyright { get; set; }
        public string Date { get; set; }
        public string Explanation { get; set; }
        public string HdUrl { get; set; }
        public MediaType media_type { get; set; }
        public string service_version { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public byte[] Image { get; set; }

        //public NasaApod(){}

        public NasaApod(string copyright, string date, string explanation, string hdUrl, string media_type, string serviceVersion, string title, string url, byte[] image)
        {
            this.Copyright = copyright;
            this.Date = date;
            this.Explanation = explanation;
            this.HdUrl = hdUrl;
            this.media_type = media_type.Equals("Video") ? MediaType.Video : MediaType.image;
            this.service_version = serviceVersion;
            this.Title = title;
            this.Url = url;
            this.Image = image;

            
            
        }
    }
}
