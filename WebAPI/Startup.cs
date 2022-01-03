using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      //Service To Manager
      services.AddSingleton<IContentService, ContentManager>();
      services.AddSingleton<IOptionService, OptionManager>();
      services.AddSingleton<IQuestionService, QuestionManager>();
      services.AddSingleton<IQuizService, QuizManager>();
      services.AddSingleton<IUserService, UserManager>();
      services.AddSingleton<IUserAnswerService, UserAnswerManager>();

      //DAL to EfDal 

      services.AddSingleton<IContentDal, EfContentDal>();
      services.AddSingleton<IOptionDal, EfOptionDal>();
      services.AddSingleton<IQuestionDal, EfQuestionDal>();
      services.AddSingleton<IQuizDal, EfQuizDal>();
      services.AddSingleton<IUserDal, EfUserDal>();
      services.AddSingleton<IUserAnswerDal, EfUserAnswerDal>();

      services.AddControllers();
      services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      services.AddCors(options => options.AddPolicy("AllowOrigin", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseCors("AllowOrigin");
      // app.UseHttpsRedirection();
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
