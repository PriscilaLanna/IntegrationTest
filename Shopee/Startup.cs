using EasyCaching.Core.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Shopee.Interfaces;
using Shopee.Models;
using Shopee.Services;
using System;

namespace Shopee
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shopee", Version = "v2" });
            });

            services.AddTransient<IProviderCache, ProviderCache>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAccessTokenService, AccessTokenService>();
            services.AddTransient<IRefreshTokenService, RefreshTokenService>();
            services.AddTransient<IGetShopInfoService, GetShopInfoService>();
            services.AddTransient<IGetProfileService, GetProfileService>();
            services.AddTransient<IGetMerchantInfoService, GetMerchantInfoService>();
            services.AddTransient<IGetOrderService, GetOrderService>();
            services.AddTransient<IGetOrderDetailService, GetOrderDetailService>();
            services.AddTransient<IPostProductService, PostProductService>();
           
            services.AddTransient<IWebHookService, WebHookService>();
            services.AddTransient<IStatusOrderWebHookService, StatusOrderWebHookService>();

            // Appsettings configuration
            services.AddOptions();
            services.Configure<PartnerConfig>(Configuration.GetSection("Shopee:PartnerConfig"));

            var serializerName = "easycaching_setting";
            services.AddEasyCaching(options =>
            {
                Action<EasyCaching.Serialization.Json.EasyCachingJsonSerializerOptions> easycaching = x =>
                {
                    x.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                };
                options.UseRedis(config =>
                {
                    config.DBConfig.Endpoints.Add(new ServerEndPoint("localhost", 6379));
                    config.DBConfig.SyncTimeout = 1500;
                    config.SerializerName = serializerName;

                }).WithJson(easycaching, serializerName);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopee v2"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}