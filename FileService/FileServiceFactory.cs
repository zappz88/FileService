using FileService.SirGawainPen;

namespace FileService
{
    public static class FileServiceFactory
    {
        public static IFileService GetFileService(FileServiceEnum fileServiceEnum, string sourcePath, string targetPath) 
        {
            IFileService fileService = null;

            switch (fileServiceEnum) 
            {
                case FileServiceEnum.SirGawainPen:
                    fileService = new SirGawainPenFileService(sourcePath, targetPath);
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
