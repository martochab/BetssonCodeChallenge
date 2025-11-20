using Betsson.OnlineWallets.Extensions;
using Betsson.OnlineWallets.Data.Extensions;
using Betsson.OnlineWallets.Web.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;

namespace Betsson.OnlineWallets.Web
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
            // Register automapper profiles
            services.AddAutoMapper(typeof(Startup));

            // Register online wallet service
            services.RegisterOnlineWalletService();

            // Register online wallet data layer
            services.RegisterOnlineWalletRepository();

            // All lowercase routes  
            services.AddRouting(options => options.LowercaseUrls = true);

            // Add controllers with fluent validation
            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<DepositRequestValidator>()
                .AddValidatorsFromAssemblyContaining<WithdrawalRequestValidator>();

            services.AddControllersWithViews();

            // Add Swagger
            services.AddSwaggerGen(options =>
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Wallets Service", Version = "v1" })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseExceptionHandler("/system/error");
            
            // Use Swagger middleware
            app.UseSwagger();

            app.UseSwaggerUI(options =>
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Betsson Online Wallets Service v1")
            );

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
