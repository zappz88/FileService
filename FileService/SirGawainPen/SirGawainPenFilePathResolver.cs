namespace FileService.SirGawainPen
{
    public class SirGawainPenFilePathResolver : IFilePathResolver
    {
        public string SourcePath { get; private set; }
        public string TargetPath { get; private set; }

        public SirGawainPenFilePathResolver(string sourcePath, string targetPath) 
        { 
            this.SourcePath = sourcePath;
            this.TargetPath = targetPath;
        }

        public string GetSourceMediaFilePath(FileTypeEnum fileTypeEnum)
        {
            string result = null;

            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = this.GetSourceVideoFilePath();
                    break;
                case FileTypeEnum.Audio:
                    result = this.GetSourceAudioFilePath();
                    break;
                case FileTypeEnum.Photo:
                    result = this.GetSourcePhotoFilePath();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public string GetSourceMediaFilePath(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return this.GetSourceMediaFilePath(fileTypeEnum);
        }

        public string GetSourceVideoFilePath()
        {
            return Path.Combine(this.SourcePath, "VIDEO");
        }

        public string GetSourceAudioFilePath()
        {
            return Path.Combine(this.SourcePath, "AUDIO");
        }

        public string GetSourcePhotoFilePath()
        {
            return Path.Combine(this.SourcePath, "PHOTO");
        }

        public string GetTargetMediaFilePath(FileTypeEnum fileTypeEnum)
        {
            string result = null;

            switch (fileTypeEnum)
            {
                case FileTypeEnum.Video:
                    result = this.GetTargetVideoFilePath();
                    break;
                case FileTypeEnum.Audio:
                    result = this.GetTargetAudioFilePath();
                    break;
                case FileTypeEnum.Photo:
                    result = this.GetTargetPhotoFilePath();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return result;
        }

        public string GetTargetMediaFilePath(string fileTypeEnumString)
        {
            FileTypeEnum fileTypeEnum = Enum.Parse<FileTypeEnum>(fileTypeEnumString);
            return this.GetTargetMediaFilePath(fileTypeEnum);
        }

        public string GetTargetVideoFilePath() 
        {
            return Path.Combine(this.GetDefaultTargetDirectoryPath(), "VIDEO");
        }

        public string GetTargetAudioFilePath()
        {
            return Path.Combine(this.GetDefaultTargetDirectoryPath(), "AUDIO");
        }

        public string GetTargetPhotoFilePath()
        {
            return Path.Combine(this.GetDefaultTargetDirectoryPath(), "PHOTO");
        }

        private string GetDefaultTargetDirectoryPath()
        {
            return Path.Combine(this.TargetPath, this.GetDefaultTargetDirectoryName(), this.GetSessionTargetDirectoryName());
        }

        private string GetDefaultTargetDirectoryName()
        {
            return $@"SirGawainPen";
        }

        private string GetSessionTargetDirectoryName()
        {
            return $@"{DateTime.Now.ToShortDateString().Replace("/", "_")} {DateTime.Now.ToShortTimeString().Replace(":", "_")}";
        }
    }
}
