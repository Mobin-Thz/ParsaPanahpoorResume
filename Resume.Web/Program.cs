using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resume.Application;
using Resume.Application.Common.Interfaces;
using Resume.Application.CQRS.Education.Command.CreateEducation;
using Resume.Application.CQRS.Education.Query;
using Resume.Application.CQRS.Reservation.Command;
using Resume.Application.CQRS.Reservation.Query;
using Resume.Application.Interfaces;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;
using Resume.Domain.Interfaces.ICommandRepository;
using Resume.Domain.Interfaces.IQueryRepository;
using Resume.Infra.Data.Repository;
using Resume.Infra.Data.Repository.Commands;
using Resume.Infra.Data.Repository.Queries;
using Resume.Infra.Data.SQLServer.Context;
using System.Text.Encodings.Web;
using System.Text.Unicode;
namespace Resume.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        builder.Services.AddApplicationServices();


        #region DbContext

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("SqlServerConnection"));
        });


        #endregion

        #region Registration 

        //Service Registration

        builder.Services.AddScoped<IThingIDoService, ThingIDoService>();
        builder.Services.AddScoped<ICustomerFeedbackService, CustomerFeedbackService>();
        builder.Services.AddScoped<ICustomerLogoService, CustomerLogoService>();
        //builder.Services.AddScoped<IEducationService, EducationService>();
        builder.Services.AddScoped<IExperienceService, ExperienceService>();
        builder.Services.AddScoped<ISkillService, SkillService>();
        builder.Services.AddScoped<IPortfolioService, PortfolioService>();
        builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
        builder.Services.AddScoped<IInformationService, InformationService>();
        builder.Services.AddScoped<IMessageService, MessageService>();
        //builder.Services.AddScoped<IReservationService, ReservationService>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Handler Registration
        //builder.Services.AddScoped<IEducationCommandHandler, CreateEducationHandler>();
        //builder.Services.AddScoped<IEducationQueryHandler, EducationQueryHandler>();
        builder.Services.AddScoped<IReservationCommandHandler, ReservationCommandHandler>();
        builder.Services.AddScoped<IReservationQueryHandler, ReservationQueryHandler>();
        //Repository Registration

        builder.Services.AddScoped<IReservationCommandRepository, ReservationCommandRepository>();
        builder.Services.AddScoped<IReservationQueryRepository, ReservationQueryRepository>();
        builder.Services.AddScoped<IEducationCommandRepository, EducationCommandRepository>();
        builder.Services.AddScoped<IEducationQueryRepository, EducationQueryRepository>();


        #region Google Recaptcha
        builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
        #endregion

        #endregion

        #region Encoder
        builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
        #endregion

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "area",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}