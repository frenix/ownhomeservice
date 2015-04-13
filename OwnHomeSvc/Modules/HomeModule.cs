using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Nancy;
using Nancy.Owin;

namespace OwnHomeSvc.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        const String IndexPage = @"
				<html><body>
				<h1>PropertyFinder service is running</h1>
				</body></html>
				";
        public HomeModule()
        {
            Get[@"/"] = parameters =>
            {
                //return Response.AsFile("index.html", "text/html");
                //return View["index"];
                return IndexPage;
            };

        }
    }
}
