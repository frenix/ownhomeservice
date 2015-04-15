using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

using OwnHomeSvc.Authentication;

namespace OwnHomeSvc
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var policy = new System.Web.Cors.CorsPolicy
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                AllowAnyOrigin = true,
                SupportsCredentials = true
            };

            policy.ExposedHeaders.Add("X-Custom-Header");
            app.UseCors (new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });

            app.Use(typeof(JwtOwinAuth));
            app.UseNancy();
        }
    }
}
