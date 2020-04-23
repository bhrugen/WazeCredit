using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Utility.AppSettingsClasses;

namespace WazeCredit.Utility.DI_Config
{
    public static class DI_AppSettingsConfig
    {
        public static IServiceCollection AddAppSettingsConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<WazeForecastSettings>(configuration.GetSection("WazeForecast"));
            services.Configure<StripeSettings>(configuration.GetSection("Stripe"));
            services.Configure<SendGridSettings>(configuration.GetSection("SendGrid"));
            services.Configure<TwilioSettings>(configuration.GetSection("Twilio"));
            return services;
        }
    }
}
