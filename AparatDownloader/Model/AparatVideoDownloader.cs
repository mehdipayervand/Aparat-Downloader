using System;
using System.Net;
using System.Threading;

namespace AparatDownloader.Model
{
    public class AparatVideoDownloader
    {
        public event DownloadedVideoCallBack OnDownloadLinkReceived;

        public void GetVideoDownloadLink(string videoUrl)
        {
            new Thread(() =>
            {
                var videoQualityist = new AparatDownloadedArgs();

                string videodata;
                using (WebClient client = new WebClient())
                {
                    videodata = client.DownloadString(videoUrl);
                }

                int where = -1;
                while ((where = videodata.IndexOf("data-ec=\"download\"", where + 1, StringComparison.Ordinal)) != -1)
                {
                    where += 18;
                    int where2 = videodata.IndexOf('"', where), where3 = videodata.IndexOf('"', where2 + 1);
                    where2 += 1;
                    string quality = (videodata.Substring(where2, where3 - where2));
                    where2 = videodata.IndexOf("href=\"", where, StringComparison.Ordinal);
                    where2 += 6;
                    where3 = videodata.IndexOf('"', where2);
                    string url = videodata.Substring(where2, where3 - where2);

                    videoQualityist.AparatVideoes.Add(new AparatVideo(quality, url));
                }

                OnDownloadLinkReceived?.Invoke(this, videoQualityist);

            }).Start();
        }
        
    }
}