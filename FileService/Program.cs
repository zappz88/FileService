// See https://aka.ms/new-console-template for more information
using FileService;
using FileService.CommandLine;
using FileService.Utility;

Console.WriteLine("Executing FileService...");

CommandLineArgumentHandler commandLineArgumentHandler = new CommandLineArgumentHandler(Environment.GetCommandLineArgs());
string targetRootPathParam = commandLineArgumentHandler.GetDestinationRootPath() ?? $@"C:\Users\arams\Desktop";
FileOperationEnum fileOperationEnum = FileOperationEnum.Move;
string archiveOperation = commandLineArgumentHandler.GetArchiveOperation();

DriveInfo[] removableDriveInfos = DriveInfoService.GetRemovableDrives();

foreach (DriveInfo removableDriveInfo in removableDriveInfos) 
{
    Console.WriteLine($@"Executing file operation '{fileOperationEnum}' on '{removableDriveInfo.Name}'...");
    foreach (FileServiceEnum fileServiceEnum in Enum.GetValues<FileServiceEnum>())
    {
        IFileService fileService = FileServiceFactory.GetFileService(fileServiceEnum, removableDriveInfo.Name, targetRootPathParam);
        Parallel.ForEach(Enum.GetValues<FileTypeEnum>(), fileTypeEnum =>
        {
            switch (fileOperationEnum) 
            { 
                case FileOperationEnum.Copy:
                    fileService.CopyMediaFiles(fileTypeEnum);
                    break;
                case FileOperationEnum.Move:
                    fileService.MoveMediaFiles(fileTypeEnum);
                    break;
                case FileOperationEnum.Delete:
                    fileService.DeleteMediaFiles(fileTypeEnum);
                    break;
                default:
                    throw new NotImplementedException();
            }
        });
    }
    Console.WriteLine($@"File operation complete.");
}

Console.WriteLine("FileService shutting down...");
