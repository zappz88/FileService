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
            List<string> commandParameters = GetCommandParameterList(ActionCommandString);
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
                if (CommandStringList.IndexOf(Args[i]) >= 0) 
                {
                    throw new ArgumentException("Commandline parsing error.", command);
                }
                return Args[i];
            }
            return null;
        }

        private string[] GetCommandParameterArray(string command)
        {
            int i = GetCommandIndex(command.ToLower());
            if (i >= 0)
            {
                i++;
                int j = i;
                while (IsValidIndex(j))
                {
                    if (CommandStringList.IndexOf(Args[j]) >= 0)
                    {
                        if (i == j)
                        {
                            throw new ArgumentException("Commandline parsing error.", command);
                        }
                        break;
                    }
                    else 
                    {
                        j++;
                    }
                };
                return Args[i..j];
            }
            return null;
        }

        private List<string> GetCommandParameterList(string command)
        {
            return GetCommandParameterArray(command).ToList();
        }
    }
}
