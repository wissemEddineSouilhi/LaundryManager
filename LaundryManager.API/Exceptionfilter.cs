using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LaundryManager.API
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public GlobalExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
           

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
            {
                // Don't display exception details unless running in Development.
                return;
            }

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
