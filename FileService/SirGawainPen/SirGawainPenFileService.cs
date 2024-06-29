namespace FileService.SirGawainPen
{

    public class SirGawainPenFileService : IFileService
    {
        private SirGawainPenFilePathResolver sirGawainPenPathResolver;

        public SirGawainPenFileService()
        {

        }

        public SirGawainPenFileService(string sourcePath, string targetPath)
        {
            this.sirGawainPenPathResolver = new SirGawainPenFilePathResolver(sourcePath, targetPath);
        }

        public string[] GetVideoFiles()
        {
            return Directory.GetFiles(this.sirGawainPenPathResolver.GetSourceVideoFilePath());
        }

        public string[] GetAudioFiles()
        {
            return Directory.GetFiles(this.sirGawainPenPathResolver.GetSourceAudioFilePath());
        }

        public string[] GetPhotoFiles()
        {
            return Directory.GetFiles(this.sirGawainPenPathResolver.GetSourcePhotoFilePath());
        }

        public string[] GetMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] result = null;
            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = this.GetVideoFiles();
                    break;
                case FileTypeEnum.Audio:
                    result = this.GetAudioFiles();
                    break;
                case FileTypeEnum.Photo:
                    result = this.GetPhotoFiles();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return result;
        }

        public string[] GetMediaFiles(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return this.GetMediaFiles(fileTypeEnum);
        }

        public void MoveMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = this.GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                string destFullDirectoryPath = this.sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Moving {mediaFiles.Length} files from '{this.sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}' to {this.sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum)}...");
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
            this.MoveMediaFiles(fileTypeEnum);
        }

        public void CopyMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = this.GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                string destFullDirectoryPath = this.sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum);
                Directory.CreateDirectory(destFullDirectoryPath);
                Console.WriteLine($@"Copying {mediaFiles.Length} files from '{this.sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}' to {this.sirGawainPenPathResolver.GetTargetMediaFilePath(fileTypeEnum)}...");
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
            this.CopyMediaFiles(fileTypeEnum);
        }

        public void DeleteMediaFiles(FileTypeEnum fileTypeEnum)
        {
            string[] mediaFiles = this.GetMediaFiles(fileTypeEnum);
            if (mediaFiles != null && mediaFiles.Length > 0)
            {
                Console.WriteLine($@"Deleting {mediaFiles.Length} files from '{this.sirGawainPenPathResolver.GetSourceMediaFilePath(fileTypeEnum)}'...");
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
            this.DeleteMediaFiles(fileTypeEnum);
        }
    }
}
