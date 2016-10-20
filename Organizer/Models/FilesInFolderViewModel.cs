using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Organizer.Models
{
    public class FilesInFolderViewModel
    {
        public List<FileInfo> files { get; set; }
        public string CurrentFolder { get; set; }
        public string folderName { get; set; }

    }
}