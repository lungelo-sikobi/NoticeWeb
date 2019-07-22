using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NoticeWeb.Filter
{
    public class BasicAuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthentication(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContex.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default", new System.Web.Routing.RouteValueDictionary
               {
                  {"controller","Admin/AccountAdmin"},
                   {"action","Index"},

                   {"returnUrl", filterContext.HttpContext.Request.RawUrl}

                   });

            }

        }
    }
}
