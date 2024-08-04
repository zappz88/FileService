namespace FileService.Services.Default
{
    public class TargetPathProvider : IPathProvider
    {
        #region Properties
        public string path { get; private set; }
        #endregion

        #region Constructors
        public TargetPathProvider(string path)
        {
            this.path = path;
        }
        #endregion

        #region Public Methods
        public string GetMediaPath(FileTypeEnum fileTypeEnum)
        {
            string result = null;

            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = GetVideoPath();
                    break;
                case FileTypeEnum.Audio:
                    result = GetAudioPath();
                    break;
                case FileTypeEnum.Photo:
                    result = GetPhotoPath();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public string GetMediaPath(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return GetMediaPath(fileTypeEnum);
        }

        public string GetVideoPath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "VIDEO");
        }

        public string GetAudioPath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "AUDIO");
        }

        public string GetPhotoPath()
        {
            return Path.Combine(GetDefaultTargetDirectoryPath(), "PHOTO");
        }

        #endregion

        #region Private Methods
        private string GetDefaultTargetDirectoryPath()
        {
            return Path.Combine(path, GetDefaultTargetDirectoryName(), GetSessionTargetDirectoryName());
        }

        private string GetDefaultTargetDirectoryName()
        {
            return $@"DefaultFileTransfer";
        }

        private string GetSessionTargetDirectoryName()
        {
            return $@"{DateTime.Now.ToShortDateString().Replace("/", "_")} {DateTime.Now.ToShortTimeString().Replace(":", "_")}";
        }
        #endregion
    }
}
