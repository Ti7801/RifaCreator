using BibliotecaBusiness.Abstractions;
using BibliotecaBusiness.Models;
using BibliotecaBusiness.Services;
using BibliotecaData.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>{

    serverOptions.ListenAnyIP(5000);// Porta 5000 para HTTP
    //serverOptions.ListenAnyIP(5001, listenOptions => listenOptions.UseHttps());// Porta 5000 para HTTP
});

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(
    (DbContextOptionsBuilder optionsBuilder) =>
    {
        string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(connectionString);
    },
    ServiceLifetime.Scoped
);


builder.Services.AddScoped<IRifaRepository, RifaRepository>();
builder.Services.AddScoped<CadastrarRifaService>();
builder.Services.AddScoped<ConsultarRifaService>();
builder.Services.AddScoped<AtualizarRifaService>();
builder.Services.AddScoped<ExcluirRifaService>();

builder.Services.AddScoped<IBilheteRepository, BilheteRepository>();
builder.Services.AddScoped<ComprarBilheteService>();
builder.Services.AddScoped<ConsultarBilheteService>();
builder.Services.AddScoped<AtualizarBilheteService>();
builder.Services.AddScoped<ExcluirBilheteService>();
builder.Services.AddScoped<SortearBilheteService>();

builder.Services.AddScoped<IRifadorRepository, RifadorRepository>();
builder.Services.AddScoped<CadastrarRifadorService>();
builder.Services.AddScoped<ConsultarRifadorService>();
builder.Services.AddScoped<AtualizarRifadorService>();
builder.Services.AddScoped<ExcluirRifadorService>();

builder.Services.AddScoped<IAfiliadoRepository, AfiliadoRepository>();
builder.Services.AddScoped<CadastrarAfiliadoService>();
builder.Services.AddScoped<ConsultarAfiliadoService>();
builder.Services.AddScoped<ConsultarAfiliadoPorIdService>();
builder.Services.AddScoped<AtualizarAfiliadoService>();
builder.Services.AddScoped<ExcluirAfiliadoService>();


//Autentication - Uso da Identidade - USUARIO/PERFIL
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

//Pegando o Token e gerando a chave encodada
var JwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(JwtSettingsSection);

var jwtSettings = JwtSettingsSection.Get<JwtSettings>();
var key = Encoding.ASCII.GetBytes(jwtSettings.Segredo);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Audiencia,
        ValidIssuer = jwtSettings.Emissor
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT desta maneira: Bearer {seu token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

//app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
