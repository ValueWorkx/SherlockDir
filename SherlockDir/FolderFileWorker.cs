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

        internal List<FileSpecs> FindFiles(string path)
        {
            List<FileSpecs> temp = new List<FileSpecs>();
            try
            {
                string pathName = path;
                string[] files = Directory.GetFiles(pathName, "*", SearchOption.AllDirectories);
                //Needs to change as there can be unauthorized access to some folders

                foreach (string file in files)
                {
                    
                    temp.Add(ConvertToFileSpec(new FileInfo(file)));
                }
            }
            catch (UnauthorizedAccessException err) { }

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
