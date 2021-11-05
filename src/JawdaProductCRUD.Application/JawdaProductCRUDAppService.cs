using System;
using System.Collections.Generic;
using System.Text;
using JawdaProductCRUD.Localization;
using Volo.Abp.Application.Services;

namespace JawdaProductCRUD
{
    /* Inherit your application services from this class.
     */
    public abstract class JawdaProductCRUDAppService : ApplicationService
    {
        protected JawdaProductCRUDAppService()
        {
            LocalizationResource = typeof(JawdaProductCRUDResource);
        }
    }
}
