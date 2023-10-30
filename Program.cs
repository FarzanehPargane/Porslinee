
using HSoft.Porsline.Business.Definitions;
using HSoft.Porsline.Business.Definitions.Factories;
using HSoft.Porsline.Business.Implementations;
using HSoft.Porsline.Business.Implementations.Factories;
using HSoft.Porsline.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PorslineDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration["ConnectionStrings:PorslineConnection"]);

});
builder.Services.AddTransient<IQuestionnaireService, QuestionnaireService>();
builder.Services.AddTransient<IQuestionnaireFactory, QuestionnaireFactory>();
builder.Services.AddTransient<IVariablesFactory, VariablesFactory>();
builder.Services.AddTransient<IQuestionnaireInformationFactory, QuestionnaireInformationFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseCors(builder => builder
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.MapControllers();

app.Run();
