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

        }
    }
}
