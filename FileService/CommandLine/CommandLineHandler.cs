using Common.CommandLine;
using Common.EnumUtil;

namespace FileService.CommandLine
{
    public class CommandLineHandler : CommandLineArgumentHandlerBase
    {
        public CommandLineHandler() : base(Parameter.ParameterList)
        {

        }

        public string GetFileServiceEnumString()
        {
            return GetParameterArg(Parameter.FileServiceParameter);
        }

        public FileServiceEnum GetFileServiceEnum()
        {
            return EnumHelper.TryParse<FileServiceEnum>(GetParameterArg(Parameter.FileServiceParameter));
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
            List<string> ParameterParameters = GetParameterArgArray(Parameter.CommandParameter).ToList();
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
