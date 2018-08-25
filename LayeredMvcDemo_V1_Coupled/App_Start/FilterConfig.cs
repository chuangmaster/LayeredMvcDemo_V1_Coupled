using System.Web;
using System.Web.Mvc;

namespace LayeredMvcDemo_V1_Coupled
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
