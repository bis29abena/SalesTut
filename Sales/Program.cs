using Microsoft.EntityFrameworkCore;
using Sales.Data;
using Sales.Repository.Interface;
using Sales.Repository;
using Sales.Businesslogic.Interface;
using Sales.Businesslogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// injecting dependencies
//builder.Services.AddSingleton<ICustomerRepository, CustomerInMemoryRepository>();
//builder.Services.AddSingleton<IProductRepository, ProductInMemoryRepository>();
//builder.Services.AddSingleton<ICategoryRepository, CategoryInMemoryRepository>();
//builder.Services.AddSingleton<IOrderRepository, OrderInMemoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();    


builder.Services.AddTransient<IOrderbusinesslogic, OrderBusinesslogic>();   
builder.Services.AddTransient<ICustomerBusinessLogic, CustomerBusinessLogic>();   
builder.Services.AddTransient<IProductBusinessLogic, ProductBusinessLogic>();
builder.Services.AddTransient<ICategoryBusinessLogic, CategoryBusinessLogic>();


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
