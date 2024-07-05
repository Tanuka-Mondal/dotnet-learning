using BicycleAPI.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BicycleAPI.AOP
{
    public class BicycleExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(DuplicateBicycleException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
            else if (context.Exception.GetType() == typeof(BicycleNotFoundException))
            {
                context.Result = new ConflictObjectResult(context.Exception.Message);
            }
        }
    }
}
