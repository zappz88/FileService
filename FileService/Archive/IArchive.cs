﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Archive
{
    public enum ArchiveOperationEnum { Default, None }

    public interface IArchive
    {
        void ArchiveDirectory(string directoryPath, string zipPath);

        void UnArchiveDirectory(string zipPath, string directoryPath);
    }
}
