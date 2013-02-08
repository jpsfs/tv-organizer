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
        private string _languages;
        private bool _downloaded;

        private static string _standard = @"^((?<series_name>.+?)[. _-]+)?s(?<season_num>\d+)[. _-]*e(?<ep_num>\d+)(([. _-]*e|-)(?<extra_ep_num>(?!(1080|720)[pi])\d+))*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private static string _fov = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d+)x(?<ep_num>\d+)(([. _-]*x|-)(?<extra_ep_num>(?!(1080|720)[pi])(?!(?<=x)264)\d+))*[\]. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private static string _numbers = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d)(?<ep_num>\d{2})*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";
        private string[] expressions = new string[] { _standard, _fov, _numbers };

        public Episode(string filename)
        {
            FilePath = filename;
            filename = Path.GetFileNameWithoutExtension(filename);

            _downloaded = false;

            foreach (string expression in expressions)
            {
                try
                {
                    var regexStandard = new Regex(expression, RegexOptions.IgnoreCase);
                    Match episode = regexStandard.Match(filename);

                    Show = Util.UppercaseFirst(episode.Groups["series_name"].Value);
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

        public string Languages
        {
            get { return _languages; }
            set { _languages = value; this.NotifyPropertyChanged("Languages"); }
        }

        public bool Downloaded
        {
            get { return _downloaded; }
            set { _downloaded = value; this.NotifyPropertyChanged("Downloaded"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
