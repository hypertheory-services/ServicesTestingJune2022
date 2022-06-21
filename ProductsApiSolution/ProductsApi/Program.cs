using ProductsApi.Adapters;
using ProductsApi.Domain;

namespace ProductsApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<ProductCatalog>();
        builder.Services.AddScoped<IProductAdapter, SelfDestructProductAdapter>();
        
        builder.Services.AddHttpClient<IOnCallDeveloperApiAdapter ,OnCallDeveloperApiAdapter>(httpClient =>
        {
            httpClient.BaseAddress = new Uri(builder.Configuration.GetValue<string>("developerUrl"));
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}