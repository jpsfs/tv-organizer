using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tv_organize.Data
{
    public class Util
    {
        public static int CountShows(List<Episode> episodeList)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var ep in episodeList)
            {
                set.Add(ep.Show);
            }

            return set.Count;
        }

        public static int CountSeasons(List<Episode> episodeList)
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var ep in episodeList)
            {
                set.Add(ep.Season);
            }

            return set.Count;
        }

        public static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}
