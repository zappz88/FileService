namespace FileService.Services.Default
{
    public class SourcePathProvider : IPathProvider
    {
        #region Properties
        public string path { get; private set; }
        #endregion

        #region Constructors
        public SourcePathProvider(string path)
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
            return Path.Combine(path, "VIDEO");
        }

        public string GetAudioPath()
        {
            return Path.Combine(path, "AUDIO");
        }

        public string GetPhotoPath()
        {
            return Path.Combine(path, "PHOTO");
        }
        #endregion
    }
}
