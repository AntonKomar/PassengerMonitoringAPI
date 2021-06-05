using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PassengersMonitoringApi.Atributes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PassengersMonitoringApi.Filters
{
    public class ModelStateValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var skip = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo.GetCustomAttributes<IgnoreModelStateValidationAttribute>().FirstOrDefault() != null;

            if (!skip && !context.ModelState.IsValid)
            {
                // Get the error messages from validation.
                var messages = string.Join(Environment.NewLine, context.ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage + " " + v.Exception));

                // Throw the exception.
                throw new ValidationException(messages);
            }

            await next();
        }
    }
}
