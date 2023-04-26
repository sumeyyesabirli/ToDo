
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Todo.Api.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication application)
        {
            application.UseExceptionHandler(builder =>
            { 

                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var cocontextFeatures= context.Features.Get<IExceptionHandlerFeature>();
                    if(cocontextFeatures != null)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = cocontextFeatures.Error.Message,
                            Title ="Hata Alındı!"
                        } ));
                    }
                });            
            }); 
        }
    }
}
