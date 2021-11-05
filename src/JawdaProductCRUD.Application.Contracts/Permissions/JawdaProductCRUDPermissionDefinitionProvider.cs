using JawdaProductCRUD.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace JawdaProductCRUD.Permissions
{
    public class JawdaProductCRUDPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
             var JawdaProductGroup = context.AddGroup(JawdaProductCRUDPermissions.GroupName, L("Permission:JawdaProduct"));

            var ProductsPermission = JawdaProductGroup.AddPermission(JawdaProductCRUDPermissions.Products.Default, L("Permission:Products"));
            ProductsPermission.AddChild(JawdaProductCRUDPermissions.Products.Create, L("Permission:Products.Create"));
            ProductsPermission.AddChild(JawdaProductCRUDPermissions.Products.Edit, L("Permission:Products.Edit"));
            ProductsPermission.AddChild(JawdaProductCRUDPermissions.Products.Delete, L("Permission:Products.Delete"));

            var CategoriesPermission = JawdaProductGroup.AddPermission(JawdaProductCRUDPermissions.Categories.Default, L("Permission:Categories"));
            CategoriesPermission.AddChild(JawdaProductCRUDPermissions.Categories.Create, L("Permission:Categories.Create"));
            CategoriesPermission.AddChild(JawdaProductCRUDPermissions.Categories.Edit, L("Permission:Categories.Edit"));
            CategoriesPermission.AddChild(JawdaProductCRUDPermissions.Categories.Delete, L("Permission:Categories.Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<JawdaProductCRUDResource>(name);
        }
    }
}
