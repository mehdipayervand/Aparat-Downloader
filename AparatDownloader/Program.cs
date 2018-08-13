using System;
using System.Linq;
using AparatDownloader.Model;

namespace AparatDownloader
{

    class Program
    {
        public static void Main(string[] args)
        {
            AparatVideoDownloader download = new AparatVideoDownloader();
            download.OnDownloadLinkReceived += Download_OnDownloadLinkReceived1;
            download.GetVideoDownloadLink("https://www.aparat.com/v/eZjCg");

            Console.ReadKey();
        }

        private static void Download_OnDownloadLinkReceived1(object sender, AparatDownloadedArgs e)
        {
           var bestQualityVideo = e.AparatVideoes.FirstOrDefault(x => x.Quality == e.AparatVideoes.Max(c=>c.Quality));
            Console.WriteLine(bestQualityVideo.Quality + " | " + bestQualityVideo.DownloadLink + Environment.NewLine);
        }

    }
}
