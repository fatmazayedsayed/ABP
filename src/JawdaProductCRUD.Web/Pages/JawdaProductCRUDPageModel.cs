using JawdaProductCRUD.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace JawdaProductCRUD.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class JawdaProductCRUDPageModel : AbpPageModel
    {
        protected JawdaProductCRUDPageModel()
        {
            LocalizationResourceType = typeof(JawdaProductCRUDResource);
        }
    }
}