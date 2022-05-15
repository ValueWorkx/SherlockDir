using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockDir
{
    internal class FolderFileWorker
    {
        private FileFilter fileFilter;
        internal List<FileSpecs> FindFiles(string path, string filterResult, string selectedFilter)
        {
            List<FileSpecs> temp = new List<FileSpecs>();

            //Create FilterObject
            if(filterResult!="" && selectedFilter!=null)
            {
                fileFilter = new FileFilter(filterResult, selectedFilter);
            }
            //Going through all the files.Filtering if filter is setup.
            try
            {
                string pathName = path;
                string[] files = Directory.GetFiles(pathName, "*", SearchOption.AllDirectories);
          

                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    if (fileFilter!= null)
                    {
                        if(fileFilter.IsFileInFilter(info))
                            temp.Add(ConvertToFileSpec(info));
                    }
                    else
                        temp.Add(ConvertToFileSpec(info));
                }
            }
            catch (UnauthorizedAccessException err) { }

            fileFilter = null;
            return temp;
        }

        private FileSpecs ConvertToFileSpec(FileInfo fileInfo)
        {
            FileSpecs temp = new FileSpecs();
            temp.Name = fileInfo.Name;
            temp.Size = (int)fileInfo.Length / 1000000;
            temp.Ext = GetFileExt(fileInfo.FullName);
            temp.FolderName = fileInfo.DirectoryName;
            temp.Type = GetFileType(temp.Ext);

            return temp;
        }

        private string GetFileExt(string path)
        {
            string[] split = path.Split(".");
            string ext = split[split.Length - 1];

            return ext;
        }


        private string GetFileType(string ext)
        {

            if (ext == "jpg" || ext == "png")
                return "image";
            else if (ext == "log")
                return "Log";
            else if (ext == "docx" || ext == "doc")
                return "MS Word";
            else if (ext == "xlsx")
                return "Excel";
            else
                return "";
        }
    }
}
