using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebUI.Services.Abstract;
using WebUI.Services.Concrete;
using Blazored.LocalStorage;

namespace WebUI
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");
      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Env.ApiURL) });

      //builder.HostEnvironment.BaseAddress

      builder.Services.AddBlazoredLocalStorage();
      builder.Services.AddSingleton<AppStateManager>();
      builder.Services.AddSingleton<AnswerStateManager>();
      builder.Services.AddSingleton(sp => new HttpClient() { BaseAddress = new Uri(Env.ApiURL) });
      builder.Services.AddSingleton<IContentService, ContentManager>();
      builder.Services.AddSingleton<IQuizService, QuizManager>();
      builder.Services.AddSingleton<ILoginService, LoginManager>();
      await builder.Build().RunAsync();
    }
  }
}
