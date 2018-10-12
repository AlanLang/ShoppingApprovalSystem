using Microsoft.AspNetCore.Antiforgery;
using ShoppingApprovalSystem.Controllers;

namespace ShoppingApprovalSystem.Web.Host.Controllers
{
    public class AntiForgeryController : ShoppingApprovalSystemControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
