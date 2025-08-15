using FinanceiroEmpresarial.Application.Interfaces;
using FinanceiroEmpresarial.Infrastructure.Context;
using FinanceiroEmpresarial.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// 1. Configurar conexão com SQL Server usando connection string do appsettings.json
builder.Services.AddDbContext<FinanceiroDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Injetar serviços (interfaces da Application com implementações da Infrastructure)
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();

// 3. Adicionar controllers
builder.Services.AddControllers();

// 4. Adicionar Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Middleware para habilitar Swagger em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 6. Middleware para redirecionar HTTP para HTTPS
app.UseHttpsRedirection();

// 7. Middleware para autorização (caso tenha autenticação)
app.UseAuthorization();

// 8. Mapear controllers
app.MapControllers();

// 9. Executar a aplicação
app.Run();
