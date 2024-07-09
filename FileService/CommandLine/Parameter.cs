namespace FileService.CommandLine
{
    public static class Parameter
    {
        //root parent location
        public static string DestinationRootParameter = "/d";
        //parent directory name
        public static string ParentRootParameter = "/p";
        //action commands
        public static string ActionParameter = "/c";

        public static List<string> ParameterList = new List<string>()
        {
            DestinationRootParameter,
            ParentRootParameter,
            ActionParameter
        };
    }
}
