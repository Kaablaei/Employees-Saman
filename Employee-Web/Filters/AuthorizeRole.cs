using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Web.Filters
{
    public class AuthorizeRole : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _role;
        public AuthorizeRole(string role)
        {
            _role = role;

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated || !user.IsInRole(_role))
            {
                context.Result = new NotFoundResult();
            }
        }
    }

}
