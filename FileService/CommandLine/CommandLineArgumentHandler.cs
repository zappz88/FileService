using FileService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.CommandLine
{
    public class CommandLineArgumentHandler : ArgumentHandler
    {
        //root parent location ie desktop
        private string DestinationRootCommandString = "/d";
        //parent directory name
        private string ParentRootCommandString = "/p";
        //action commands
        private string ActionCommandString = "/c";

        private List<string> CommandStringList = new List<string>() { "/d", "/p", "/c" };

        public CommandLineArgumentHandler(string[] args) : base(args)
        {
        }

        public string GetDestinationRoot()
        {
            return GetCommandParameter(DestinationRootCommandString);
        }

        public string GetParentRoot()
        {
            return GetCommandParameter(ParentRootCommandString);
        }

        public List<FileOperationEnum> GetFileOperations()
        {
            List<string> commandParameters = GetCommandParameters(ActionCommandString);
            if (commandParameters.Count > 0) 
            {
                List<FileOperationEnum> fileOperationEnumsList = new List<FileOperationEnum>();
                foreach (string commandParameter in commandParameters) 
                {
                    fileOperationEnumsList.Add(EnumParser.TryParse<FileOperationEnum>(commandParameter));
                }
                return fileOperationEnumsList;
            }

            return null;
        }

        private int GetCommandIndex(string command) 
        {
            return Array.IndexOf(Args, command);
        }

        private string GetCommandParameter(string command)
        {
            int i = GetCommandIndex(command.ToLower());
            if (i >= 0)
            {
                i++;
                if (IsValidIndex(i) && CommandStringList.IndexOf(Args[i]) == -1) 
                {
                    return Args[i];
                }
            }
            return null;
        }

        private List<string> GetCommandParameters(string command)
        {
            int i = GetCommandIndex(command.ToLower());
            if (i >= 0) 
            {
                i++;
                List<string> parameters = new List<string>();
                while (IsValidIndex(i) && CommandStringList.IndexOf(Args[i]) == -1)
                {
                    parameters.Add(Args[i]);
                    i++;
                };
                return parameters;
            }
            return null;
        }
    }
}
