using System.Web;
using System.Web.Mvc;

namespace Maddelavedu_Exam02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
