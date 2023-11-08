using LibraryBookService.Models;
using LibraryBookService.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;


namespace LibraryBookService.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //var param = context.ActionArguments.SingleOrDefault();
            var param = context.ActionArguments.FirstOrDefault();
            if (param.Value == null)
            {
                context.Result = new BadRequestObjectResult("object is null");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                     .Where(x => x.Value.Errors.Count > 0)
                     .ToDictionary(x => x.Key, x => x.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorResponse = new ErrorResponse();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value) 
                    {
                        var errorDetails = new ErrorDetails()
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        errorResponse.Errors.Add(errorDetails);

                    }
                }

                context.Result = new BadRequestObjectResult(errorResponse);
                return;
            }
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            //     var result = await next();
        }

    }
}
