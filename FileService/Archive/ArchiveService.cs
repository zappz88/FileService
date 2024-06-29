using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Archive
{

    public class ArchiveService : IArchive
    {
        public void ArchiveDirectory(string directoryPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(directoryPath, zipPath, CompressionLevel.Optimal, false);
        }

        public void UnArchiveDirectory(string zipPath, string directoryPath)
        {
            ZipFile.ExtractToDirectory(zipPath, directoryPath, true);
        }
    }
}
