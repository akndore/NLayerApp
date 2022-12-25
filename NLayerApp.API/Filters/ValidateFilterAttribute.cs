﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayerApp.Core.DTOs;
using System.Net;

namespace NLayerApp.API.Filters
{
    public class ValidateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                context.Result =
                    new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(HttpStatusCode.BadRequest, errors));


            }
        }
    }
}
