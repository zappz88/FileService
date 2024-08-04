namespace FileService
{
    public enum FileTypeEnum { Video, Audio, Photo }

    public enum FileOperationEnum { Copy, Move, Delete, Archive }

    public enum FileServiceEnum { Media }

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

    public interface IPathProvider
    {
        string GetMediaPath(FileTypeEnum fileTypeEnum);

        string GetMediaPath(string fileTypeEnumString);

        string GetVideoPath();

        string GetAudioPath();

        string GetPhotoPath();
    }
}
