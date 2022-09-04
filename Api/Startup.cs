using System.Reflection;
using System.Text;
using Infra.Contexts;
using Infra.Repositories;
using Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services;
using Services.Interfaces;

namespace Api;

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
        services.AddControllers();

        // Connect to PostgreSQL Database
        services.AddDbContext<AppDbContext>(
            options => options.UseNpgsql("name=ConnectionStrings:DbConnection"));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Cursos EaD API",
                Description = "Uma API para o gerenciamento de cursos EaD"
            });

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
 
        // Configure the authentication and set default scheme
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options => {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;

               var key = Encoding.ASCII.GetBytes(TokenSettings.Secret);
               options.TokenValidationParameters = new TokenValidationParameters
               {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key), // Key that will be used for validation
                    ValidateIssuer = false,
                    ValidateAudience = false
               }; // Parameters used for token validation
            });

        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<AuthService>();
        
        services.AddTransient<UserService>();
        services.AddTransient<CourseService>();
        services.AddTransient<LessonService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UsePathBase("/api");

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "v1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseCors(x => x
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        );
        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
