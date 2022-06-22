using Microsoft.OpenApi.Models;
using TicketForEvent.Business.Abstract;
using TicketForEvent.Business.Concrete;
using TicketForEvent.DAL.Context;

namespace TicketForEvent.WebAPI
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
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TicketForEvent.WebAPI", Version = "v1" });
            });
            services.AddDbContext<TicketForEventDbContext>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ITownshipService, TownshipService>();
            services.AddScoped<INeighborhoodService, NeighborhoodService>();
            services.AddScoped<IStreetService, StreetService>();
            services.AddScoped<IOpenAddressService, OpenAddressService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<ISalonSeatService, SalonSeatService>();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketForEvent.WebAPI v1"));
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
