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
            app.UseCors(CorsOptions.AllowAll);
            //app.Use(typeof(JwtOwinAuth));
            app.UseNancy();
        }
    }
}
