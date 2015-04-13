using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OwnHomeSvc
{
    class Program
    {
        private static ManualResetEvent _quitEvent = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            var port = 8088;
            if (args.Length > 0)
            {
                int.TryParse(args[0], out port);
            }

            Console.CancelKeyPress += (sender, eArgs) =>
            {
                _quitEvent.Set();
                eArgs.Cancel = true;
            };

            //var url = string.Format("http://*:{0}", port);
            var url = string.Format("http://+:{0}", port);

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", port);
                _quitEvent.WaitOne();
            }
        }
    }
}
