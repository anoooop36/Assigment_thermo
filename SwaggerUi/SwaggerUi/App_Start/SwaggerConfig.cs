using System.Web.Http;
using WebActivatorEx;
using SwaggerUi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerUi
{
    public class SwaggerConfig
    {
        private static string GetXmlCommentsPath()
        {
            //IncludeXmlComments
            return string.Format(@"{0}\bin\SwaggerUi.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }

        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "SwaggerUi");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                })
                .EnableSwaggerUi(c =>
                {
                });
        }
    }
}
