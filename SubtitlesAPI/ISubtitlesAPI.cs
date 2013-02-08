using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tv_organize.Data;

namespace tv_organize.SubtitlesAPI
{
    public interface ISubtitlesAPI
    {
        void Search(Episode ep);
        void Download(Episode ep);
    }
}
