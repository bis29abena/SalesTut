using Sales.InMemoryRepository;
using Sales.InMemoryRepository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// injecting dependencies
builder.Services.AddSingleton<ICustomerRepository, CustomerInMemoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductInMemoryRepository>();
builder.Services.AddSingleton<ICategoryRepository, CategoryInMemoryRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderInMemoryRepository>();

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
