using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockDir
{
    internal class FileFilter
    {
        private enum FilterTypes {Name, Size, Extension, Folder };
        private FilterTypes filterType;

        private string filterString;

        public FileFilter(string filter, string selectedFilter)
        {
            switch (selectedFilter)
            {
                case "Name":
                    filterType = FilterTypes.Name;
                    break;
                case "Size (mb)":
                    filterType = FilterTypes.Size;
                    break;
                case "Extension":
                    filterType = FilterTypes.Extension;
                    break;
                case "Folder":
                    filterType = FilterTypes.Folder;
                    break;
                default:
                    break;
            }

            filterString = filter;
        }

        internal bool IsFileInFilter(FileInfo file)
        {
            bool result = false;

            if(filterType == FilterTypes.Name)
            {
                if (file.Name.Contains(filterString))
                    result = true;
                else
                    result = false;
            }
            else if (filterType == FilterTypes.Extension)
            {

            }
            else if (filterType == FilterTypes.Size)
            {

            }
            else if (filterType == FilterTypes.Folder)
            {
                if(file.DirectoryName.Contains(filterString))
                    result = true;
                else
                    result = false;
            }

            return result;
        }
    }
}
