namespace FileService
{
    public enum FileTypeEnum { Video, Audio, Photo }

    public enum FileOperationEnum { Copy, Move, Delete }

    public enum FileServiceEnum { SirGawainPen }

    public interface IFileService
    {
        string[] GetVideoFiles();

        string[] GetAudioFiles();

        string[] GetPhotoFiles();

        string[] GetMediaFiles(FileTypeEnum fileTypeEnum);

        string[] GetMediaFiles(string fileTypeEnumString);

        void CopyMediaFiles(FileTypeEnum fileTypeEnum);

        void CopyMediaFiles(string fileTypeEnumString);

        void MoveMediaFiles(FileTypeEnum fileTypeEnum);

        void MoveMediaFiles(string fileTypeEnumString);

        void DeleteMediaFiles(FileTypeEnum fileTypeEnum);

        void DeleteMediaFiles(string fileTypeEnumString);
    }

    public interface IFilePathResolver
    {
        string GetSourceMediaFilePath(FileTypeEnum fileTypeEnum);

        string GetSourceMediaFilePath(string fileTypeEnumString);

        string GetSourceVideoFilePath();

        string GetSourceAudioFilePath();

        string GetSourcePhotoFilePath();

        string GetTargetMediaFilePath(FileTypeEnum fileTypeEnum);

        string GetTargetMediaFilePath(string fileTypeEnumString);

        string GetTargetVideoFilePath();

        string GetTargetAudioFilePath();

        string GetTargetPhotoFilePath();
    }
}
