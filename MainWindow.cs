using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using tv_organize.Data;
using tv_organize.SubtitlesAPI;

namespace tv_organizer
{
    public partial class MainWindow : Form
    {
        private BindingList<Episode> _episodeList;

        public BindingList<Episode> EpisodeList
        {
          get { return _episodeList; }
            set { _episodeList = value;}
        }

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                EpisodeList = new BindingList<Episode>();
                dataGridViewEpisodes.DataSource = EpisodeList;

                DataGridViewComboBoxColumn colCombo = new DataGridViewComboBoxColumn();
                colCombo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colCombo.HeaderText = "Available Languages";
                colCombo.Name = "AvailableLanguages";
                dataGridViewEpisodes.Columns.Add(colCombo);

                checkBoxManualPath.DataBindings.Add(new Binding("Checked", textBoxSelectedPath, "Enabled"));

            }
            catch { }
        }


        private void dataGridViewEpisodes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewEpisodes.Rows)
            {
                var episode = row.DataBoundItem as Episode;
                if (episode != null)
                {
                    if (episode.ErrorHash) row.DefaultCellStyle.BackColor = Color.PaleVioletRed;

                    var combo = row.Cells["AvailableLanguages"] as DataGridViewComboBoxCell;
                    if (episode.AvailableLanguages != null)
                    {
                        combo.Items.Clear();
                        foreach (string language in episode.AvailableLanguages)
                        {
                            combo.Items.Add(language);
                        }
                        
                    }
                    
                }
            }
        }

        private void buttonChoosePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();

            textBoxSelectedPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void textBoxSelectedPath_TextChanged(object sender, EventArgs e)
        {
            if (Text.Length > 0)
            {
                buttonSearchForEpisodes.Enabled = true;
                buttonDownloadSubtitles.Enabled = false;
                buttonSearchSubtitles.Enabled = false;
                buttonOrganizeFolders.Enabled = false;
                comboBoxPrimaryLanguage.Enabled = false;
            }
            else
            {
                buttonSearchForEpisodes.Enabled = false;
            }
        }

        private void buttonSearchForEpisodes_Click(object sender, EventArgs e)
        {
            buttonChoosePath.Enabled = false;
            buttonSearchSubtitles.Enabled = false;
            buttonOrganizeFolders.Enabled = false;

            backgroundWorkerSearchEpisodes.RunWorkerAsync(textBoxSelectedPath.Text);

            toolStripProgressBarLabel.Text = "Search for Episodes Started!";

            
        }


        #region Background Worker Search Episodes
        private void backgroundWorkerSearchEpisodes_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker searchEpisodesWorker = sender as BackgroundWorker;
            string path = e.Argument as string;

            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                            .Where(file => file.EndsWith("avi", true, null) || file.EndsWith("mp4", true, null) || file.EndsWith("mkv", true, null))
                            .ToList();

            //if files.Count > 250 send object true (maybe file list is too big to be processed)
            searchEpisodesWorker.ReportProgress(100, files.Count > 250);

            List<Episode> episodeList = new List<Episode>();
            for (int i = 0; i < files.Count; i++)
            {
                episodeList.Add(new Episode(files[i]));
                
                searchEpisodesWorker.ReportProgress((int)((i+1) * 100.0 / (double)files.Count));
            }

            e.Result = episodeList;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerSearchEpisodes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EpisodeList.Clear();

            List<Episode> list = e.Result as List<Episode>;
            foreach (Episode ep in list)
            {
                EpisodeList.Add(ep);
            }

            buttonChoosePath.Enabled = true;

            if (EpisodeList.Count > 0)
            {
                buttonSearchSubtitles.Enabled = true;
                buttonOrganizeFolders.Enabled = true;
            }

            toolStripProgressBarLabel.Text = "Search for Episodes Complete!";
            
        }
        #endregion

        private void buttonSearchSubtitles_Click(object sender, EventArgs e)
        {
            toolStripProgressBarLabel.Text = "Search for Subtitles Started!";
            backgroundWorkerSearchSubtitles.RunWorkerAsync(EpisodeList.ToList());
        }

        #region Background Worker Search Subtitles
        private void backgroundWorkerSearchSubtitles_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker searchEpisodesWorker = sender as BackgroundWorker;
            List<Episode> episodes = e.Argument as List<Episode>;

            ISubtitlesAPI client = new EasySubtitles();

            for (int i = 0; i < episodes.Count; i++)
            {
                client.Search(episodes[i]);

                searchEpisodesWorker.ReportProgress((int)((i+1) * 100.0 / (double)episodes.Count));
            }
        }

        private void backgroundWorkerSearchSubtitles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBarLabel.Text = "Search for Subtitles Complete!";
            buttonDownloadSubtitles.Enabled = true;
            comboBoxPrimaryLanguage.Enabled = true;

        }
        #endregion

        private void buttonDownloadSubtitles_Click(object sender, EventArgs e)
        {
            toolStripProgressBarLabel.Text = "Downloading Subtitles!";
            backgroundWorkerDownloadSubtitles.RunWorkerAsync(EpisodeList.ToList());
        }

        #region Background Worker Download Subtitles
        private void backgroundWorkerDownloadSubtitles_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker searchEpisodesWorker = sender as BackgroundWorker;
            List<Episode> episodes = e.Argument as List<Episode>;

            ISubtitlesAPI client = new EasySubtitles();

            for (int i = 0; i < episodes.Count; i++)
            {
                client.Download(episodes[i]);

                searchEpisodesWorker.ReportProgress((int)(i*100.0 / episodes.Count));
            }
        }

        private void backgroundWorkerDownloadSubtitles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBarLabel.Text = "Subtitles Download Complete!";
        }

        #endregion

        private void buttonOrganizeFolders_Click(object sender, EventArgs e)
        {
            toolStripProgressBarLabel.Text = "Organizing Folders!";
            backgroundWorkerOrganizeFolders.RunWorkerAsync(new { EpisodeList = EpisodeList.ToList(), Path = textBoxSelectedPath.Text });
        }

        #region Background Worker Organize Folders

        private void backgroundWorkerOrganizeFolders_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker organizeFoldersWorker = sender as BackgroundWorker;

            var argument = Cast(e.Argument, new { EpisodeList = new List<Episode>(), Path = "" });
            List<Episode> episodes = argument.EpisodeList;

            int showsCount = Util.CountShows(episodes);
            int seasonsCount = Util.CountSeasons(episodes);

            for (int i = 0; i < episodes.Count; i++)
            {
                OrganizeEpisode(episodes[i], argument.Path, showsCount, seasonsCount);
            }
        }

        private void backgroundWorkerOrganizeFolders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBarLabel.Text = "Files Organized!";
            buttonSearchForEpisodes.PerformClick();
        }

        void OrganizeEpisode(Episode ep, string path, int showsCount, int seasonsCount)
        {
            //Set Current path
            Directory.SetCurrentDirectory(path);

            if (showsCount > 1)
            {
                if (!Directory.Exists(ep.Show))
                    Directory.CreateDirectory(ep.Show);

                Directory.SetCurrentDirectory(ep.Show);

            }

            if (seasonsCount > 1)
            {
                var dirname = "Season " + ep.Season;
                if (!Directory.Exists(dirname))
                    Directory.CreateDirectory(dirname);

                Directory.SetCurrentDirectory(dirname);
            }

            var foldername = ep.Season + (ep.EpisodeNumber < 10 ? "0" : "") + ep.EpisodeNumber;
            Directory.CreateDirectory(foldername);
            Directory.SetCurrentDirectory(foldername);

            File.Move(ep.FilePath, Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(ep.FilePath)));

            string pathtosrt = Path.Combine(Path.GetDirectoryName(ep.FilePath), Path.GetFileNameWithoutExtension(ep.FilePath)) + ".srt";
            if (File.Exists(pathtosrt))
            {
                File.Move(pathtosrt, Path.GetFileNameWithoutExtension(ep.FilePath) + ".srt");
            }
        }

        T Cast<T>(object obj, T type)
        {
           return (T)obj;
        }

        #endregion

        private void linkLabelEasySubtitles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://thesubdb.com");
            
        }

        private void linkLabelDevelopedBy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jpsfs.com");
        }

        private void dataGridViewEpisodes_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGrid = sender as DataGridView;
            if (dataGrid.Columns[dataGrid.CurrentCell.ColumnIndex].Name == "AvailableLanguages" && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectionChangeCommitted -= LastColumnComboSelectionChanged;
                comboBox.SelectionChangeCommitted += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            DataGridView dataGrid = combo.Parent.Parent as DataGridView;
            Episode ep = EpisodeList[dataGrid.CurrentRow.Index];
            if(combo.SelectedItem != null) ep.Language = combo.SelectedItem.ToString();
        }

        private void comboBoxPrimaryLanguage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (Episode episode in EpisodeList)
            {
                if(episode.AvailableLanguages == null) continue;
                if(episode.AvailableLanguages.Contains(comboBoxPrimaryLanguage.SelectedItem.ToString())){
                    episode.Language = comboBoxPrimaryLanguage.SelectedItem.ToString();
                }
            }
        }

    }
}
