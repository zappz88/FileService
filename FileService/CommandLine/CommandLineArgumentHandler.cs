using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.CommandLine
{
    public class CommandLineArgumentHandler : ArgumentHandler
    {
        public CommandLineArgumentHandler(string[] args) : base(args)
        {
        }

        public string GetDestinationRootPath()
        {
            return IsValidIndex(1) ? this.Args[1] : null;
        }

        //public FileOperationEnum GetFileOperation()
        //{
        //    return IsValidIndex(2) ? Enum.Parse<FileOperationEnum>(this.Args[2]) : FileOperationEnum.None;
        //}

        public string GetArchiveOperation()
        {
            return IsValidIndex(2) ? this.Args[2] : null;
        }
    }
}
