using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Migrations;

namespace TodoListApp
{
    public class Startup
	{

		readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			var connectionString = Configuration.GetConnectionString("DefaultConnection");
			var originUrlAllowed = "http://localhost:4200";

			services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins, builder => builder.WithOrigins(originUrlAllowed)));

			// services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));

			services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

			services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

			// Enable swagger
			services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoListApp", Version = "v1" }));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoListApp v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(item => item.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));

			app.UseAuthorization();

			app.UseEndpoints(endpoints => endpoints.MapControllers());

		}
	}
}
