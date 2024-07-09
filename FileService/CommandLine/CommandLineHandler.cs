using Common.CommandLine;
using Common.EnumUtil;

namespace FileService.CommandLine
{
    public class CommandLineHandler : CommandLineArgumentHandler
    {
        public CommandLineHandler() : base(Parameter.ParameterList)
        {

        }

        public string GetDestinationRoot()
        {
            return GetParameterArg(Parameter.DestinationRootParameter);
        }

        public string GetParentRoot()
        {
            return GetParameterArg(Parameter.ParentRootParameter);
        }

        public List<FileOperationEnum> GetFileOperations()
        {
            List<string> ParameterParameters = GetParameterArgArray(Parameter.ActionParameter).ToList();
            if (ParameterParameters.Count > 0) 
            {
                List<FileOperationEnum> fileOperationEnumsList = new List<FileOperationEnum>();
                foreach (string ParameterParameter in ParameterParameters) 
                {
                    fileOperationEnumsList.Add(EnumHelper.TryParse<FileOperationEnum>(ParameterParameter));
                }
                return fileOperationEnumsList;
            }

            return null;
        }
    }
}
