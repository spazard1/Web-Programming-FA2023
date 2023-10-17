using Hobbits.Filters;
using Hobbits.Services;

namespace Hobbits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<HobbitsDatabase>();

            builder.Services.AddScoped<GuidIdGenerator>();
            builder.Services.AddScoped<HobbitLogger>();
            builder.Services.AddScoped<TimeOfDayGenerator>();
            builder.Services.AddScoped<RequestLoggingFilter>();
            builder.Services.AddScoped<RequestIdFilter>();

#if DEBUG
            builder.Services.AddScoped<IRequestIdGenerator, GuidIdGenerator>();
# else
            builder.Services.AddTransient<IRequestIdGenerator, GuidIdGenerator>();
#endif


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("*"));

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}