// See https://aka.ms/new-console-template for more information
using Common.System;
using FileService;
using FileService.CommandLine;

Console.WriteLine("Executing FileService...");

CommandLineHandler commandLineHandler = new CommandLineHandler();
FileServiceEnum fileServiceEnum = commandLineHandler.GetFileServiceEnum();
List<FileOperationEnum> fileOperationEnums = commandLineHandler.GetFileOperations();
string destinationRoot = commandLineHandler.GetDestinationRoot();

DriveInfo[] removableDriveInfos = DriveInfoService.GetRemovableDrives();

foreach (DriveInfo removableDriveInfo in removableDriveInfos) 
{
    foreach (FileOperationEnum fileOperationEnum in fileOperationEnums)
    {
        Console.WriteLine($@"Executing file operation '{fileOperationEnum}' on '{removableDriveInfo.Name}'...");
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
        Console.WriteLine($@"File operation complete.");
    }
}

Console.WriteLine("FileService shutting down...");
