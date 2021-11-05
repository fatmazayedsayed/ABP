using System.Threading.Tasks;
using JawdaProductCRUD.Localization;
using JawdaProductCRUD.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace JawdaProductCRUD.Web.Menus
{
    public class JawdaProductCRUDMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var administration = context.Menu.GetAdministration();
            var l = context.GetLocalizer<JawdaProductCRUDResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    JawdaProductCRUDMenus.Home,
                    l["Menu:Home"],
                    "~/",
                    icon: "fas fa-home",
                    order: 0
                )
            );

            var ProductStoreMenu = new ApplicationMenuItem(
              "ProductsStore",
              l["Menu:ProductStore"],
              icon: "fa fa-Product"
          );

            context.Menu.AddItem(ProductStoreMenu);
            ProductStoreMenu.AddItem(new ApplicationMenuItem(
                   "ProductsStore.Products",
                   l["Menu:Products"],
                   url: "/Products"
               ));
           // if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))
            {
                ProductStoreMenu.AddItem(new ApplicationMenuItem(
                    "ProductsStore.Categories",
                    l["Menu:Categories"],
                    url: "/Categories"
                ));
            }



            if (MultiTenancyConsts.IsEnabled)
            {
                administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
            }
            else
            {
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
            administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
        }
    }
}
