using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            SetCurrentDir(new DirectoryInfo("C:/"));
        }

        private DirectoryInfo currentDir;

        private void SetCurrentDir(DirectoryInfo dir) {
            currentDir = dir;

            tbAddress.Text = dir.FullName;
            btUp.IsEnabled = currentDir.Parent != null;

            listFiles.Items.Clear();
            try
            {
                foreach (FileSystemInfo info in dir.GetFileSystemInfos())
                    listFiles.Items.Add(info);
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            if (currentDir.Parent != null)
              SetCurrentDir(currentDir.Parent);
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dir = new DirectoryInfo(tbAddress.Text);

            if (dir.Exists)
                SetCurrentDir(dir);
            else
                MessageBox.Show("Wrong dir");
        }

        private void listFiles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            object item = listFiles.SelectedItem;

            if (item == null)
                return;

            if (item is DirectoryInfo)
                SetCurrentDir((DirectoryInfo)item);
        }

        private void AddSearchResults(IEnumerable<FileInfo> files)
        {
            foreach (object file in files) 
                listSearchResults.Items.Add(file);
        }

        private void UpdateProgress(int progress, int max)
        {
            progressSearch.Maximum = max;
            progressSearch.Value = progress;
        }

        private void SearchInDir( DirectoryInfo dir, bool topDir )
        {
            try
            {
                IEnumerable<FileInfo> files = dir.GetFiles().Where(file => file.Name.Contains(tbSearchTerm.Text));

                Dispatcher.BeginInvoke(DispatcherPriority.Normal,new Action<IEnumerable<FileInfo>>(AddSearchResults), files);
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (topDir)
                {
                    for (int i = 0; i < dirs.Length; ++i)
                    {
                        SearchInDir(dirs[i], false);
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action<int, int>(UpdateProgress), i + 1, dirs.Length);
                    }
                }
                else
                {
                    foreach (DirectoryInfo info in dirs)
                        SearchInDir(info, false);
                }
                
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        delegate void SearchDelegate(DirectoryInfo info, bool topDir);

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            new SearchDelegate(SearchInDir).BeginInvoke(currentDir, true, (d) => MessageBox.Show("Search completed"), null);
        }

    }
}
