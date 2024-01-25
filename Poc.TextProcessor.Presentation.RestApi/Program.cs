using Poc.TextProcessor.Business.Logic;
using Poc.TextProcessor.Business.Logic.Abstractions;
using Poc.TextProcessor.Presentation.RestApi.Infrastructure.FilterAttributes;
using Poc.TextProcessor.ResourceAccess.Mappers;
using Poc.TextProcessor.ResourceAccess.Repositories;
using Poc.TextProcessor.ResourceAccess.Repositories.Abstractions;
using Poc.TextProcessor.Services;
using Poc.TextProcessor.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TextService
builder.Services.AddTransient<ITextService, TextService>();
builder.Services.AddTransient<ITextLogic, TextLogic>();
builder.Services.AddTransient<ITextRepository, TextRepository>();
builder.Services.AddTransient<ITextMapper, TextMapper>();

//TextSortService
builder.Services.AddTransient<ITextSortService, TextSortService>();
builder.Services.AddTransient<ITextSortLogic, TextSortLogic>();
builder.Services.AddTransient<ITextSortRepository, TextSortRepository>();
builder.Services.AddTransient<ITextSortMapper, TextSortMapper>();
builder.Services.AddControllers();

//Add filter exceptions.
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionHandlingFilter());
});

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