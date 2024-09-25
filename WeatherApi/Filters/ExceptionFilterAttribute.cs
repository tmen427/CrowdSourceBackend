using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using WeatherApi.Models;

namespace WeatherApi.Filters
{
    public class ExceptionFilterAttribute : Attribute, IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext context)
        {
         
       
            int statusCode = (int)HttpStatusCode.InternalServerError;
           
            if (context.Exception is CustomException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }

         //   var status = context.HttpContext.Response.StatusCode.ToString();



            context.Result = new ObjectResult(new CustomResponse
            {
                //message from the throw 
                Message = context.Exception.Message,
                StatusCode = statusCode.ToString(),
                Sucess = false
            });
            await Task.FromResult(0);
        }
    }
}
