using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using share_a_plate_backend.Configuration;
using share_a_plate_backend.Data;
using share_a_plate_backend.Interfaces;
using share_a_plate_backend.Repositories;
using share_a_plate_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure automapper 
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// configure DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDonationRepository, DonationRepository>();


// register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IJwtServicecs, JwtService>();
builder.Services.AddScoped<IDonationService, DonationService>();

// Json options for serialization and deserialization of JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
// Add JWT authentication via extension method
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Share A Plate API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// add JWT authentication via extension method
builder.Services.AddJwtAuthentication(builder.Configuration);

// add CORS policy to allow requests from the frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader() // Allow any header: means the frontend can send any header
                   .AllowAnyMethod() // Allow any method: means the frontend can send any HTTP method
                   .AllowCredentials();// Allow cookies: means the frontend can send cookies
                   

        });
});

// Define the ProblemDetails middleware to handle exceptions
builder.Services.AddProblemDetails();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// enable CORS policy
app.UseCors("AllowFrontend");
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

// This add the Authentication Middleware
app.UseAuthentication();
app.UseAuthorization();

// This will add the ProblemDetails middleware to the pipeline so that it can handle exceptions
// and return the appropriate response
app.UseExceptionHandler();
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllers();

app.Run();
