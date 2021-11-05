using JawdaProductCRUD.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace JawdaProductCRUD.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class JawdaProductCRUDController : AbpController
    {
        protected JawdaProductCRUDController()
        {
            LocalizationResource = typeof(JawdaProductCRUDResource);
        }
    }
}