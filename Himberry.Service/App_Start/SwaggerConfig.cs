using System.Web.Http;
using Swashbuckle.Application;
using System;

namespace Himberry.Service
{
    public static class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v2", "Himberry.Service api");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\bin\Himberry.Service.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
