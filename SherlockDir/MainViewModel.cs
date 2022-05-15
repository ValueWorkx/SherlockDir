using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace SherlockDir
{
    public class MainViewModel
    {
        private ObservableCollection <FileSpecs> files;
        private FolderFileWorker worker;
        public MainViewModel()
        {
            files = new ObservableCollection<FileSpecs>();
            worker = new FolderFileWorker();
        }

        public void GetFiles(string path, string filterText, string selectedFilter)
        {
            List<FileSpecs> fileList = worker.FindFiles(path, filterText, selectedFilter);
            foreach(FileSpecs file in fileList)
            {
                files.Add(file);
            }
        }

        public ObservableCollection<FileSpecs> Files
        {
            get { return files; }
           
        }

        public ObservableCollection<FileSpecs> ClearFiles()
        {
            files = new ObservableCollection<FileSpecs>();
            return files;
            
        }
    }
}

