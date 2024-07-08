// See https://aka.ms/new-console-template for more information
using FileService;
using FileService.CommandLine;
using FileService.Utility;

Console.WriteLine("Executing FileService...");

CommandLineArgumentHandler commandLineArgumentHandler = new CommandLineArgumentHandler(Environment.GetCommandLineArgs());
string targetRootPathParam = commandLineArgumentHandler.GetDestinationRoot();
List<FileOperationEnum> fileOperationEnums = commandLineArgumentHandler.GetFileOperations();

DriveInfo[] removableDriveInfos = DriveInfoService.GetRemovableDrives();

foreach (DriveInfo removableDriveInfo in removableDriveInfos) 
{
    foreach (FileOperationEnum fileOperationEnum in fileOperationEnums)
    {
        Console.WriteLine($@"Executing file operation '{fileOperationEnum}' on '{removableDriveInfo.Name}'...");
        foreach (FileServiceEnum fileServiceEnum in Enum.GetValues<FileServiceEnum>())
        {
            IFileService fileService = FileServiceFactory.GetFileService(fileServiceEnum, removableDriveInfo.Name, targetRootPathParam);
            switch (fileOperationEnum)
            {
                case FileOperationEnum.Copy:
                    fileService.CopyAllMediaFiles();
                    break;
                case FileOperationEnum.Move:
                    fileService.MoveAllMediaFiles();
                    break;
                case FileOperationEnum.Delete:
                    fileService.DeleteAllMediaFiles();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        Console.WriteLine($@"File operation complete.");
    }
}

Console.WriteLine("FileService shutting down...");
