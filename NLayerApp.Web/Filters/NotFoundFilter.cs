using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerApp.Core.DTOs;
using NLayerApp.Core.Entities;
using NLayerApp.Core.Services;
using System.Net;

namespace NLayerApp.Web.Filters
{
    /// <summary>
    /// [ServiceFilter(typeof(NotFoundFilter<Product>))]
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            var errorModel = new ErrorModel(new List<string>() { $"{typeof(T).Name} not found." });

            context.Result =
                new RedirectToActionResult("Error", "Home", errorModel);
        }
    }
}
