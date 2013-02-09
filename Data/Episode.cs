using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace tv_organize.Data
{
    public class Episode : INotifyPropertyChanged
    {
        private string _filePath;
        private string _show;
        private int _season;
        private int _episodeNumber;
        private string _language;
        private bool _downloadSub;
        private string[] _availableLanguages;

        private bool _errorHash = false;

        [Browsable(false)]
        public bool ErrorHash
        {
            get { return _errorHash; }
            set { _errorHash = value; this.NotifyPropertyChanged("ErrorHash"); }
        }

        public string[] AvailableLanguages
        {
            get { return _availableLanguages; }
            set { _availableLanguages = value; this.NotifyPropertyChanged("AvailableLanguages"); }
        }

        private static string _standard = @"^((?<series_name>.+?)[. _-]+)?s(?<season_num>\d+)[. _-]*e(?<ep_num>\d+)(([. _-]*e|-)(?<extra_ep_num>(?!(1080|720)[pi])\d+))*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private static string _fov = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d+)x(?<ep_num>\d+)(([. _-]*x|-)(?<extra_ep_num>(?!(1080|720)[pi])(?!(?<=x)264)\d+))*[\]. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private static string _numbers = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d)(?<ep_num>\d{2})*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private string[] expressions = new string[] { _standard, _fov, _numbers };

        public Episode(string filename)
        {
            FilePath = filename;
            filename = Path.GetFileNameWithoutExtension(filename);

            _downloadSub = false;

            foreach (string expression in expressions)
            {
                try
                {
                    var regexStandard = new Regex(expression, RegexOptions.IgnoreCase);
                    Match episode = regexStandard.Match(filename);

                    string tmpShow = episode.Groups["series_name"].Value;
                    tmpShow = tmpShow.Replace('.', ' ');

                    Show = Util.UppercaseEachWord(tmpShow);
                    Season = Int32.Parse(episode.Groups["season_num"].Value);
                    EpisodeNumber = Int32.Parse(episode.Groups["ep_num"].Value);
                    break;
                }
                catch
                {
                    continue;
                }
            }
        }


        public string Show
        {
            get { return _show; }
            set { _show = value; this.NotifyPropertyChanged("Show"); }
        }

        public int Season
        {
            get { return _season; }
            set { _season = value; this.NotifyPropertyChanged("Season"); }
        }

        public int EpisodeNumber
        {
            get { return _episodeNumber; }
            set { _episodeNumber = value; this.NotifyPropertyChanged("EpisodeNumber"); }
        }

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; this.NotifyPropertyChanged("FilePath"); }
        }

        public string Language
        {
            get { return _language; }
            set { _language = value; this.NotifyPropertyChanged("Language"); }
        }

        public bool DownloadSub
        {
            get { return _downloadSub; }
            set { _downloadSub = value; this.NotifyPropertyChanged("DownloadSub"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
