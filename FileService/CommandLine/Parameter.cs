namespace FileService.CommandLine
{
    public static class Parameter
    {
        //root parent location
        public static string FileServiceParameter = "/s";
        //root parent locationServiceParameter
        public static string DestinationRootParameter = "/d";
        //parent directory name
        public static string ParentRootParameter = "/p";
        //action commands
        public static string CommandParameter = "/c";
        //contiguous action delimiter eg dest, move | dest copy
        public static string CommandDelimiter = "|";

        public static List<string> ParameterList = new List<string>()
        {
            FileServiceParameter,
            DestinationRootParameter,
            ParentRootParameter,
            CommandParameter,
            CommandDelimiter
        };
    }
}
