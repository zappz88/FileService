namespace FileService
{

    public class FileService : IFileService
    {
        #region Properties
        private FilePathProvider filePathProvider;
        #endregion

        #region Constructors
        public FileService()
        {

        }

        public FileService(string sourcePath, string targetPath)
        {
            filePathProvider = new FilePathProvider(sourcePath, targetPath);
        }
        #endregion

        #region Public Methods
        public string[] GetVideoFiles()
        {
            return Directory.GetFiles(filePathProvider.GetSourceVideoFilePath());
        }

        public string[] GetAudioFiles()
        {
            return Directory.GetFiles(filePathProvider.GetSourceAudioFilePath());
        }

        public string[] GetPhotoFiles()
        {
            return Directory.GetFiles(filePathProvider.GetSourcePhotoFilePath());
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
                string destFullDirectoryPath = filePathProvider.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Moving {mediaFiles.Length} files from '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}' to {filePathProvider.GetTargetMediaFilePath(fileTypeEnum)}...");
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
                Console.WriteLine($@"{mediaFiles.Length} {fileTypeEnum} files found in '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}'.");
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
                string destFullDirectoryPath = filePathProvider.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Copying {mediaFiles.Length} files from '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}' to {filePathProvider.GetTargetMediaFilePath(fileTypeEnum)}...");
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
                Console.WriteLine($@"{mediaFiles.Length} {fileTypeEnum} files found in '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}'.");
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
                Console.WriteLine($@"Deleting {mediaFiles.Length} files from '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}'...");
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
                Console.WriteLine($@"{mediaFiles.Length} {fileTypeEnum} files found in '{filePathProvider.GetSourceMediaFilePath(fileTypeEnum)}'.");
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
