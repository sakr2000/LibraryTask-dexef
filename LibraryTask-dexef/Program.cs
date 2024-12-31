using LibraryTask_dexef.Application.Common;
using LibraryTask_dexef.WebApi.Extensions;
using static LibraryTask_dexef.Application.Common.Exceptions.ProgramExeption;

namespace LibraryTask_dexef
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration.Get<AppSettings>()
                ?? throw ProgramException.AppsettingNotSetException();

            builder.Services.AddSingleton(configuration);
            var app = await builder.ConfigureServices(configuration).ConfigurePipelineAsync(configuration);

            await app.RunAsync();
        }
    }
}
