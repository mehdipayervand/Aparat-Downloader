using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace AparatDownloader
{
    public class Aparat
    {
        public delegate void DArgs(object sender, AArgs e);
        public event DArgs OnDownloadLinkReceived;

        private string _VURL;
        public Aparat(string Video_Url)
        {
            _VURL = Video_Url;
        }
        public void GetVideoDownloadLink()
        {
            new Thread(() =>
            {
                WebClient client = new WebClient();
                string videodata = client.DownloadString(_VURL);
                client.Dispose();
                int where = -1;
                while ((where = videodata.IndexOf("data-ec=\"download\"", where + 1)) != -1)
                {
                    where += 18;
                    int where2 = videodata.IndexOf('"', where), where3 = videodata.IndexOf('"', where2 + 1);
                    where2 += 1;
                    string quality = (videodata.Substring(where2, where3 - where2));
                    where2 = videodata.IndexOf("href=\"", where);
                    where2 += 6;
                    where3 = videodata.IndexOf('"', where2);
                    string url = videodata.Substring(where2, where3 - where2);
                    if(OnDownloadLinkReceived != null)
                    {
                        OnDownloadLinkReceived(this, new AArgs(quality, url));
                    }
                }
            }).Start();
        }
        public string VideoUrl
        {
            get { return _VURL; }
        }
        public class AArgs
        {
            private string _quality, _link;
            public AArgs(string quality, string link)
            {
                _quality = quality;
                _link = link;
            }
            public string Quality
            {
                get { return _quality; }
            }
            public string DownloadLink
            {
                get { return _link; }
            }
        }
    }
}
