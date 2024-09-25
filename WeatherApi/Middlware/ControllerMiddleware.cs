
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WeatherApi.Middlware
{
    public class ControllerMiddleware : IMiddleware
    {

        public readonly ILogger<ControllerMiddleware> _logger;
        public ControllerMiddleware(ILogger<ControllerMiddleware> logger)
        {
            _logger = logger;
        }


        
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try

            {
                _logger.LogInformation(context.Request.Path);
                _logger.LogInformation(context.Response.StatusCode.ToString());

                Console.WriteLine("this is comming from the middleware pipeline ");
                await next(context);
            }
       
            catch (Exception ex)
            {
                _logger.LogInformation("this is from the MIDDLWARE"); 
                _logger.LogInformation(ex.Message);
            //    _logger.LogWarning(ex.StackTrace);


            }
        
        }
    }
}
