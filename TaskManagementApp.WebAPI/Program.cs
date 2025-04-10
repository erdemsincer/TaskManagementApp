using Microsoft.EntityFrameworkCore;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Concrete;
using TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers;
using TaskManagementApp.DataAccessLayer.Abstract;
using TaskManagementApp.DataAccessLayer.Contexts;
using TaskManagementApp.DataAccessLayer.EntityFrameworkCore;
using TaskManagementApp.DataAccessLayer.Repositories;
using MediatR;

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

// MediatR (CQRS)
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetProjectQueryHandler).Assembly);
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

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
