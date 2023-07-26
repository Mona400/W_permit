namespace WorkPermit.API.Helper

{
    public static class Router
    {
        public const string SingleRoute = "/{id}";
        public const string root = "Api";
        public const string vertion = "V1";
        public const string Rule = root + "/" + vertion + "/";

        public static class WorkPermitRouting
        {
            public const string Prefix = Rule + "WorkPermit";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete";
            public const string EditWorkPermitStatus = Prefix + "/Status";

        }



    }
}
