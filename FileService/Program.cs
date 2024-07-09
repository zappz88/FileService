// See https://aka.ms/new-console-template for more information
using Common.System;
using FileService;
using FileService.CommandLine;

Console.WriteLine("Executing FileService...");

CommandLineHandler commandLineArgumentHandler = new CommandLineHandler();
string destinationRoot = commandLineArgumentHandler.GetDestinationRoot();
List<FileOperationEnum> fileOperationEnums = commandLineArgumentHandler.GetFileOperations();

DriveInfo[] removableDriveInfos = DriveInfoService.GetRemovableDrives();

foreach (DriveInfo removableDriveInfo in removableDriveInfos) 
{
    foreach (FileOperationEnum fileOperationEnum in fileOperationEnums)
    {
        Console.WriteLine($@"Executing file operation '{fileOperationEnum}' on '{removableDriveInfo.Name}'...");
        foreach (FileServiceEnum fileServiceEnum in Enum.GetValues<FileServiceEnum>())
        {
            IFileService fileService = FileServiceFactory.GetFileService(fileServiceEnum, removableDriveInfo.Name, destinationRoot);
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
