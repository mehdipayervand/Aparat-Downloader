namespace AparatDownloader.Model
{
    public class AparatVideo
    {
        public AparatVideo(string quality, string link)
        {
            Quality = quality;
            DownloadLink = link;
        }
        public string Quality { get; }

        public string DownloadLink { get; }
    }
}