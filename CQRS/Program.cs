using CQRS.CQRS.Handlers;
using CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<StudentContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; Database=StudentDb; Integrated security=true");
});
builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddScoped<GetStudentByIdQueryHandler>();
//builder.Services.AddScoped<GetStudentsQueryHandler>();
//builder.Services.AddScoped<CreateStudentCommandHandler>();
//builder.Services.AddScoped<RemoveStudentCommandHandler>();
//builder.Services.AddScoped<UpdateStudentCommandHandler>();

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;    
});

var app = builder.Build();

app.MapControllers();

app.Run();
