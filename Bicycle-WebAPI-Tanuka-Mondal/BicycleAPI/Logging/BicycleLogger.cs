using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BicycleAPI.Logging
{
    public class BicycleLogger:ActionFilterAttribute
    {
        readonly string filename = "BicycleLogging.txt";
        string logFilePath;
        DateTime startTime;
        DateTime endTime;
        TimeSpan totalTime;
        public BicycleLogger(IWebHostEnvironment environment) 
        {
            string rootPath = environment.ContentRootPath;
            logFilePath = rootPath + "\\Logging" + $"\\{filename}";
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            startTime = DateTime.Now;
            var controllerName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)filterContext.Controller)
                .ControllerContext.ActionDescriptor.ActionName;
            File.AppendAllText(logFilePath, $"Start Time: {startTime} \tControllerName: {controllerName} \tActionName: {actionName} \t ");
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            endTime = DateTime.Now;
            totalTime = endTime - startTime;
            File.AppendAllText(logFilePath, $"End Time: {endTime} \tTotal time: {totalTime.TotalMilliseconds}\n");
        }
    }
}
