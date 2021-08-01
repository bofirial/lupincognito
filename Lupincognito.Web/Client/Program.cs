using System;
using System.Net.Http;
using System.Threading.Tasks;
using Fluxor;
using Lupincognito.Web.Client.Messenger;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lupincognito.Web.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            var currentAssembly = typeof(Program).Assembly;
            builder.Services.AddFluxor(options => options.ScanAssemblies(currentAssembly));

            builder.Services.AddSingleton<IGameHubMessenger, GameHubMessenger>();

            await builder.Build().RunAsync();
        }
    }
}
