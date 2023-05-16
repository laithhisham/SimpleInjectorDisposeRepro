using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using SimpleInjectorDisposeRepro;

//var builder = WebApplication.CreateBuilder(args);
var container = new Container();

var host = Host.CreateDefaultBuilder()
                .ConfigureServices(ConfigureServices)
                .UseConsoleLifetime()
                .Build()
                .UseSimpleInjector(container);
container.Verify();

var testDisposable = container.GetInstance<TestDisposableAsyncClass>();
Console.WriteLine(testDisposable.TestMethod());

var cancellationToken = new CancellationTokenSource();

await host.RunAsync(cancellationToken.Token);

void ConfigureServices(IServiceCollection services)
{
    services.AddSimpleInjector(container);
    container.RegisterSingleton<TestDisposableAsyncClass, TestDisposableAsyncClass>();
}

