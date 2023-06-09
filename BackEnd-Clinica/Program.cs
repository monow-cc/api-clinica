using BackEnd_Clinica.HUB;
using BackEnd_Clinica.MIddleware;
using BackEnd_Clinica.Program;
using Microsoft.Extensions.FileProviders;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddInjections();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCorsPolicy();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.DbConnectionSetup(builder.Configuration);
builder.Services.AddSignalR();

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;

}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();


app.UseMiddleware(typeof(ErrorHandleMiddleware));
app.UseMiddleware(typeof(AuthenticatorMiddleware));
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "Archives")),
    RequestPath = "/Archives"
});
app.UseEndpoints(endpoints =>
{   endpoints.MapControllers();
    endpoints.MapHub<ClinicaHUB>("/ClinicaHub");
});


app.Run();
