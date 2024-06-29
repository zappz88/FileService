namespace FileService
{

    public class FileService : IFileService
    {
        private FilePathResolver sirGawainPenPathResolver;

        public FileService()
        {

        }

        public FileService(string sourcePath, string targetPath)
        {
            sirGawainPenPathResolver = new FilePathResolver(sourcePath, targetPath);
        }

        public string[] GetVideoFiles()
        {
            return Directory.GetFiles(sirGawainPenPathResolver.GetSourceVideoFilePath());
        }

        public string[] GetAudioFiles()
        {
            return Directory.GetFiles(sirGawainPenPathResolver.GetSourceAudioFilePath());
        }

        public string[] GetPhotoFiles()
        {
            return Directory.GetFiles(sirGawainPenPathResolver.GetSourcePhotoFilePath());
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
                string destFullDirectoryPath = sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Moving {mediaFiles.Length} files from '{sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}' to {sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum)}...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    File.Move(fileInfo.FullName, Path.Combine(destFullDirectoryPath, fileInfo.Name));
                });
                Console.WriteLine($@"Moved files.");
            }
        }

        public void MoveMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            MoveMediaFiles(fileTypeEnum);
        }

        public void CopyMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                string destFullDirectoryPath = sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Copying {mediaFiles.Length} files from '{sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}' to {sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum)}...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    File.Copy(fileInfo.FullName, Path.Combine(destFullDirectoryPath, fileInfo.Name));
                });
                Console.WriteLine($@"Copied files.");
            }
        }

        public void CopyMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            CopyMediaFiles(fileTypeEnum);
        }

        public void DeleteMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                Console.WriteLine($@"Deleting {mediaFiles.Length} files from '{sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}'...");
                Parallel.ForEach(mediaFiles, mediaFile =>
                {
                    FileInfo fileInfo = new FileInfo(mediaFile);
                    File.Delete(fileInfo.FullName);
                });
                Console.WriteLine($@"Deleted files.");
            }
        }

        public void DeleteMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            DeleteMediaFiles(fileTypeEnum);
        }
    }
}
