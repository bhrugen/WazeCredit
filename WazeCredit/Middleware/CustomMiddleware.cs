using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Service.LifeTimeExample;

namespace WazeCredit.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,TransientService transientService,
            ScopedService scopedService, SingletonService singletonService)
        {
            context.Items.Add("CustomMiddlewareTransient", "Transient Middleware - " + transientService.GetGuid());
            context.Items.Add("CustomMiddlewareScoped", "Scoped Middleware - " + scopedService.GetGuid());
            context.Items.Add("CustomMiddlewareSingleton", "Singleton Middleware - " + singletonService.GetGuid());

            await _next(context);
        }
    }
}
