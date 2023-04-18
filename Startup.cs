using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CottrellAssignment6.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CottrellAssignment6;
internal class Startup
{
    public IServiceProvider ConfigureServices()
    {
        IServiceCollection services = new ServiceCollection();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.AddFile("app.log");
        });

        // Add new lines of code here to register any interfaces and concrete services you create
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<IFileService, FileService>();

        return services.BuildServiceProvider();
    }
}
