using DeliVeggieService.Entity;
using DeliVeggieService.MongoDB;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using DeliVeggieService.HelperExtensions;
using DeliVeggieService.Logger;
using DeliVeggieService.Logger.ExceptionHandlerMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeliVeggieService", Version = "v1" });
});

BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

// Add MongoDB collections to the container
builder.Services.AddMongo().AddMongoRepository<Product>("products");
builder.Services.AddMongo().AddMongoRepository<PriceReductions>("pricereductions");
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeliVeggieService v1"));
}
//configure exception middleware
app.UseMiddleware(typeof(ExceptionMiddleware));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
