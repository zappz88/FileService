namespace FileService
{
    public class FilePathProvider : IFilePathResolver
    {
        #region Properties
        public string SourcePath { get; private set; }
        public string TargetPath { get; private set; }
        #endregion

        #region Constructors
        public FilePathProvider(string sourcePath, string targetPath)
        {
            SourcePath = sourcePath;
            TargetPath = targetPath;
        }
        #endregion

        #region Public Methods
        public string GetSourceMediaFilePath(FileTypeEnum fileTypeEnum)
        {
            string result = null;

            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = GetSourceVideoFilePath();
                    break;
                case FileTypeEnum.Audio:
                    result = GetSourceAudioFilePath();
                    break;
                case FileTypeEnum.Photo:
                    result = GetSourcePhotoFilePath();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public string GetSourceMediaFilePath(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return GetSourceMediaFilePath(fileTypeEnum);
        }

        public string GetSourceVideoFilePath()
        {
            return Path.Combine(SourcePath, "VIDEO");
        }

        public string GetSourceAudioFilePath()
        {
            return Path.Combine(SourcePath, "AUDIO");
        }

        public string GetSourcePhotoFilePath()
        {
            return Path.Combine(SourcePath, "PHOTO");
        }

        public string GetTargetMediaFilePath(FileTypeEnum fileTypeEnum)
        {
            string result = null;

            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = GetTargetVideoFilePath();
                    break;
                case FileTypeEnum.Audio:
                    result = GetTargetAudioFilePath();
                    break;
                case FileTypeEnum.Photo:
                    result = GetTargetPhotoFilePath();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public string GetTargetMediaFilePath(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return GetTargetMediaFilePath(fileTypeEnum);
        }

        public string GetTargetVideoFilePath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "VIDEO");
        }

        public string GetTargetAudioFilePath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "AUDIO");
        }

        public string GetTargetPhotoFilePath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "PHOTO");
        }

        #endregion

        #region Private Methods
        private string GetDefaultTargetDirectoryPath()
        {
            return Path.Combine(TargetPath, GetDefaultTargetDirectoryName(), GetSessionTargetDirectoryName());
        }

        private string GetDefaultTargetDirectoryName()
        {
            return $@"SirGawainPen";
        }

        private string GetSessionTargetDirectoryName()
        {
            return $@"{DateTime.Now.ToShortDateString().Replace("/", "_")} {DateTime.Now.ToShortTimeString().Replace(":", "_")}";
        }
        #endregion
    }
}
