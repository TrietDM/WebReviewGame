using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebReviewGame.Middleware
{
    public class RedirectToPostIndexMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectToPostIndexMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/")
            {
                context.Response.Redirect("/Post/Index");
                return;
            }

            await _next(context);
        }
    }
}
