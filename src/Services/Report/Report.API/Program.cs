using Report.API.Repositories.Abstract;
using Report.API.Repositories.Concrete;
using EventBus.Messages.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPhoneBookReportRepository, PhoneBookReportRepository>();
builder.Services.AddScoped<IReportDetailRepository, ReportDetailRepository>();
builder.Services.AddMasstransitWithRabbitMQ(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
