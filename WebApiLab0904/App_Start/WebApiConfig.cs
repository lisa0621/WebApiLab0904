using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebApiLab0904.Controllers;

namespace WebApiLab0904
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            
            //排版 不太需要
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            //駝峰式屬性名稱 js的一般屬性名稱是小寫開頭 對前端工程師比較友善
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            // Web API 設定和服務
            // 將 Web API 設定成僅使用 bearer 權杖驗證。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //將CheckModelStateAttribute加入到全站共用的ActionFilter
            //config.Filters.Add(new CheckModelStateAttribute());
            config.Filters.Add(new HandleMyErrorAttribute());

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
