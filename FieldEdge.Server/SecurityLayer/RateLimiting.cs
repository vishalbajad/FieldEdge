using Microsoft.AspNetCore.RateLimiting;

namespace FieldEdge.Server.SecurityLayer
{
    public static class Security
    {
        public static void AddRateLimitingServices(this IServiceCollection services)
        {
            services.AddRateLimiter(rateLimiterOptions =>
            {
                rateLimiterOptions.AddSlidingWindowLimiter("sliding", options =>
                {
                    options.PermitLimit = 10;
                    options.Window = TimeSpan.FromSeconds(10);
                    options.SegmentsPerWindow = 2;
                    options.QueueLimit = 5;
                });
            });

        }
    }
}
