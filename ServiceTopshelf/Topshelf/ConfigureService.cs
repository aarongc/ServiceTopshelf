using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ServiceTopshelf.Topshelf
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<VendorApiService>(service =>
                {
                    service.ConstructUsing(s => new VendorApiService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                configure.RunAsLocalSystem();
                configure.SetServiceName("VendorApiService");
                configure.SetDisplayName("VP VendorApi Service");
                configure.SetDescription("Vendor Portal VendorApi Service (Curtis 1000)");
            });
        }
    }
}
