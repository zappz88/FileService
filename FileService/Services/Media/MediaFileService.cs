namespace FileService.Services.Default
{

    public class MediaFileService : IFileService
    {
        #region Properties
        private SourcePathProvider sourcePathProvider;
        private TargetPathProvider targetPathProvider;
        #endregion

        #region Constructors
        public MediaFileService()
        {

        }

        public MediaFileService(string sourcePath, string targetPath)
        {
            sourcePathProvider = new SourcePathProvider(sourcePath);
            targetPathProvider = new TargetPathProvider(targetPath);
        }
        #endregion

        #region Public Methods
        public string[] GetVideoFiles()
        {
            string path = sourcePathProvider.GetVideoPath();
            if (Directory.Exists(path)) 
            {
                return Directory.GetFiles(path);
            }
            return null;
        }

        public string[] GetAudioFiles()
        {
            string path = sourcePathProvider.GetAudioPath();
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(sourcePathProvider.GetAudioPath());
            }
            return null;
        }

        public string[] GetPhotoFiles()
        {
            string path = sourcePathProvider.GetPhotoPath();
            if (Directory.Exists(path))
            {
                return Directory.GetFiles(sourcePathProvider.GetPhotoPath());
            }
            return null;
        }

        public string[] GetMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] result = null;
            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = GetVideoFiles();
                    break;
                case FileTypeEnum.Audio:
                    result = GetAudioFiles();
                    break;
                case FileTypeEnum.Photo:
                    result = GetPhotoFiles();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return result;
        }

        public string[] GetMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return GetMediaFiles(fileTypeEnum);
        }

        public void MoveMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                string destFullDirectoryPath = targetPathProvider.GetMediaPath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Moving {mediaFiles.Length} files from '{sourcePathProvider.GetMediaPath(fileTypeEnum)}' to {targetPathProvider.GetMediaPath(fileTypeEnum)}...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    Console.WriteLine($@"Moving {fileInfo.Name}...");
                    File.Move(fileInfo.FullName, Path.Combine(destFullDirectoryPath, fileInfo.Name));
                    Console.WriteLine($@"{fileInfo.Name} moved.");
                });
                Console.WriteLine($@"Moved files.");
            }
            else
            {
                Console.WriteLine($@"No {fileTypeEnum} files found in '{sourcePathProvider.GetMediaPath(fileTypeEnum)}'.");
            }
        }

        public void MoveMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            MoveMediaFiles(fileTypeEnum);
        }

        public void MoveAllMediaFiles()
        {
            Parallel.ForEach(Enum.GetValues<FileTypeEnum>(), MoveMediaFiles);
        }

        public void CopyMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                string destFullDirectoryPath = targetPathProvider.GetMediaPath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Copying {mediaFiles.Length} files from '{sourcePathProvider.GetMediaPath(fileTypeEnum)}' to {targetPathProvider.GetMediaPath(fileTypeEnum)}...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    Console.WriteLine($@"Copying {fileInfo.Name}...");
                    File.Copy(fileInfo.FullName, Path.Combine(destFullDirectoryPath, fileInfo.Name));
                    Console.WriteLine($@"{fileInfo.Name} copied.");
                });
                Console.WriteLine($@"Copied files.");
            }
            else
            {
                Console.WriteLine($@"No {fileTypeEnum} files found in '{sourcePathProvider.GetMediaPath(fileTypeEnum)}'.");
            }
        }

        public void CopyMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            CopyMediaFiles(fileTypeEnum);
        }

        public void CopyAllMediaFiles()
        {
            Parallel.ForEach(Enum.GetValues<FileTypeEnum>(), CopyMediaFiles);
        }

        public void DeleteMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                Console.WriteLine($@"Deleting {mediaFiles.Length} files from '{sourcePathProvider.GetMediaPath(fileTypeEnum)}'...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    Console.WriteLine($@"Deleting {fileInfo.Name}...");
                    File.Delete(fileInfo.FullName);
                    Console.WriteLine($@"{fileInfo.Name} deleted.");
                });
                Console.WriteLine($@"Deleted files.");
            }
            else
            {
                Console.WriteLine($@"No {fileTypeEnum} files found in '{sourcePathProvider.GetMediaPath(fileTypeEnum)}'.");
            }
        }

        public void DeleteMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            DeleteMediaFiles(fileTypeEnum);
        }

        public void DeleteAllMediaFiles()
        {
            Parallel.ForEach(Enum.GetValues<FileTypeEnum>(), DeleteMediaFiles);
        }
        #endregion
    }
}
