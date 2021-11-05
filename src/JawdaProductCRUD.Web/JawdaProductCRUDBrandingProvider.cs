using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace JawdaProductCRUD.Web
{
    [Dependency(ReplaceServices = true)]
    public class JawdaProductCRUDBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "JawdaProductCRUD";
    }
}
