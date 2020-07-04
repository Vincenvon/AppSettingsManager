using System.Web;
using System.Web.Mvc;

namespace AppSettingsManager461.TestClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
