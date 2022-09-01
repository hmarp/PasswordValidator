using PasswordValidator.Factories;
using PasswordValidator.Rules;
using PasswordValidator.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IValidatorFactory, PasswordValidatorFactory>();
builder.Services.AddScoped<IPasswordValidator, SimpleValidator>();
builder.Services.AddScoped<IPasswordValidator, AdvancedValidator>();

builder.Services.AddScoped<IRule, AdvancedLengthRule>();
builder.Services.AddScoped<IRule, SimpleLengthRule>();
builder.Services.AddScoped<IRule, AdvancedNumberRule>();
builder.Services.AddScoped<IRule, SimpleNumberRule>();
builder.Services.AddScoped<IRule, ContainsSpecialCharacterRule>();

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
