using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Archive
{
    public interface IArchive
    {
        void ArchiveDirectory(string directoryPath, string zipPath);

        void ExtractDirectory(string zipPath, string directoryPath);
    }
}
