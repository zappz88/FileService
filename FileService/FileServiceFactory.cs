using Common.EnumUtil;
using FileService.Services.Default;

namespace FileService
{
    public static class FileServiceFactory
    {
        public static IFileService GetFileService(FileServiceEnum fileServiceEnum)
        {
            IFileService fileService = null;

            switch (fileServiceEnum)
            {
                case FileServiceEnum.Media:
                    fileService = new MediaFileService();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return fileService;
        }

        public static IFileService GetFileService(string fileServiceEnumString)
        {
            FileServiceEnum fileServiceEnum = EnumHelper.TryParse<FileServiceEnum>(fileServiceEnumString);
            return GetFileService(fileServiceEnum);
        }

        public static IFileService GetFileService(FileServiceEnum fileServiceEnum, string sourcePath, string targetPath) 
        {
            IFileService fileService = null;

            switch (fileServiceEnum) 
            {
                case FileServiceEnum.Media:
                    fileService = new MediaFileService(sourcePath, targetPath);
                    break;
                default:
                    throw new NotImplementedException();
            }

            return fileService;
        }

        public static IFileService GetFileService(string fileServiceEnumString, string sourcePath, string targetPath) 
        {
            FileServiceEnum fileServiceEnum = Enum.Parse<FileServiceEnum>(fileServiceEnumString);
            return GetFileService(fileServiceEnum, sourcePath, targetPath);
        }
    }
}
