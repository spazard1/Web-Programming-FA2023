using Hobbits.Services;

namespace Hobbits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<GuidIdGenerator>();
            builder.Services.AddTransient<HobbitLogger>();
            builder.Services.AddTransient<TimeOfDayGenerator>();

            builder.Services.AddSingleton<HobbitsDatabase>();

#if DEBUG
            builder.Services.AddTransient<IRequestIdGenerator, NumberIdGenerator>();
# else
            builder.Services.AddTransient<IRequestIdGenerator, GuidIdGenerator>();
#endif


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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