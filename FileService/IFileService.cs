namespace FileService
{
    public enum FileTypeEnum { Video, Audio, Photo }

    public enum FileOperationEnum { Copy, Move, Delete }

    public enum FileServiceEnum { Default }

    public interface IFileService
    {
        string[] GetVideoFiles();

        string[] GetAudioFiles();

        string[] GetPhotoFiles();

        string[] GetMediaFiles(FileTypeEnum fileTypeEnum);

        string[] GetMediaFiles(string fileTypeEnumString);

        void CopyMediaFiles(FileTypeEnum fileTypeEnum);

        void CopyMediaFiles(string fileTypeEnumString);

        void CopyAllMediaFiles();

        void MoveMediaFiles(FileTypeEnum fileTypeEnum);

        void MoveMediaFiles(string fileTypeEnumString);

        void MoveAllMediaFiles();

        void DeleteMediaFiles(FileTypeEnum fileTypeEnum);

        void DeleteMediaFiles(string fileTypeEnumString);

        void DeleteAllMediaFiles();
    }

    public interface IFilePathProvider
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
