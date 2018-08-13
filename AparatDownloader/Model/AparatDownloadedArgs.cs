using System.Collections.Generic;

namespace AparatDownloader.Model
{
    public class AparatDownloadedArgs
    {
        public AparatDownloadedArgs(string videoUrl)
        {
            VideoUrl = videoUrl;
            AparatVideoes = new List<AparatVideo>();
        }

        public string VideoUrl { get;private set; }
        public AparatDownloadedArgs()
        {
            AparatVideoes = new List<AparatVideo>();
        }

        public List<AparatVideo> AparatVideoes { get; set; }
    }
}