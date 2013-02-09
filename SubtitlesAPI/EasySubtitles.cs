using System;
using System.IO;
using System.Text;
using System.Net;
using tv_organize.Data;

namespace tv_organize.SubtitlesAPI
{
    public class EasySubtitles : ISubtitlesAPI
    {
        private static string _url = "http://api.thesubdb.com/";
        private static string _language = "pt,en";
        private static string _userAgent = "SubDB/1.0 (TvSeriesOrganizer/0.1; https://github.com/jpsfs/tv-organizer)";

        public static string Language
        {
            get
            {
                return EasySubtitles._language;
            }
            set
            {
                EasySubtitles._language = value;
            }
        }

        public static string Url
        {
            get
            {
                return EasySubtitles._url;
            }
            set
            {
                EasySubtitles._url = value;
            }
        }

        public void Search(Episode ep)
        {
            string fileName = Path.GetFileNameWithoutExtension(ep.FilePath);

            string hash = "";
            try
            {
                hash = tv_organizer.SubtitlesAPI.HashGenerator.Get(ep.FilePath);
            }
            catch
            {
                //Error generating the hash file... just continue
                ep.ErrorHash = true;
                return;
            }
            //Handle HTTP Request
            string url = String.Format((EasySubtitles.Url + "?action=search&hash={0}"), hash);

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, _userAgent);
            
            webClient.OpenReadCompleted += webClient_OpenReadCompleted;
            webClient.OpenReadAsync(new Uri(url), ep);


        }

        void webClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Episode ep = e.UserState as Episode;

            try
            {
                StreamReader sr = new StreamReader(e.Result);
                // read the response into a string and show the result.
                ep.Language = sr.ReadToEnd();
                ep.AvailableLanguages = ep.Language.Split(',');

                ep.DownloadSub = true;
                sr.Close();
            }
            catch { }
            
        }

        public void Download(Episode ep)
        {
            if (!ep.DownloadSub || ep.AvailableLanguages == null || ep.AvailableLanguages.Length == 0) return;

            string fileName = Path.GetFileNameWithoutExtension(ep.FilePath);
            string hash = "";

            try
            {
                hash = tv_organizer.SubtitlesAPI.HashGenerator.Get(ep.FilePath);
            }
            catch
            {
                //Error generating the hash file... just continue
                ep.ErrorHash = true;
                return;
            }
            
            //Handle HTTP Request
            string url = String.Format((EasySubtitles.Url + "?action=download&language={0}&hash={1}&name={2}"), EasySubtitles.Language, hash, fileName);

            WebClient webClient = new WebClient();
            webClient.Headers.Add(HttpRequestHeader.UserAgent, _userAgent);
            webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            webClient.DownloadFileAsync(new Uri(url), Path.GetDirectoryName(ep.FilePath) + Path.DirectorySeparatorChar + fileName + ".srt", ep);
        
        }

        void webClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Episode ep = e.UserState as Episode;
                ep.DownloadSub = false;
            }
        }
    }
}
