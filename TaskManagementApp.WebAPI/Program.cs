using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Concrete;
using TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers;
using TaskManagementApp.BusinessLayer.Services.Security;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Repositories;
using TaskManagementApp.BusinessLayer.Validators; // validator klasörün buradaysa

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetProjectQueryHandler).Assembly);
});

// FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserValidator>();

// CORS (Gerekirse UI erişimi için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Generic Repositories
builder.Services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

// Services
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<ITaskItemService, TaskItemManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();

// DALs
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IRoleDal, EfRoleDal>();
builder.Services.AddScoped<IProjectDal, EfProjectDal>();
builder.Services.AddScoped<ITaskItemDal, EfTaskItemDal>();

// Custom Services
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtService, JwtService>();

// JWT Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // 🌐 UI'dan çağrı yapılacaksa gerekli

app.UseAuthentication(); // 🔐 önce auth middleware
app.UseAuthorization();

app.MapControllers();

app.Run();
