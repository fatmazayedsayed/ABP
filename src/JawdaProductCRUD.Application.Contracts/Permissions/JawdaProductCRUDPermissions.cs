namespace JawdaProductCRUD.Permissions
{
    public static class JawdaProductCRUDPermissions
    {
        public const string GroupName = "JawdaProductCRUD";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";
 
        public static class Products
        {
            public const string Default = GroupName + ".Products";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
        public static class Categories
        {
            public const string Default = GroupName + ".Categories";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}