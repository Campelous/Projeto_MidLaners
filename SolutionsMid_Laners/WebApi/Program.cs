using AutoMapper;
using Data.Config;
using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.ViewModels;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextBase>
    (options => options.UseSqlServer("Data Source=DESKTOP-L4QJGKA;Initial Catalog=MINIMAL_API;User ID=sa;Password=1234"));

builder.Services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));

builder.Services.AddSingleton<IChampion, RepositoryChampion>();
builder.Services.AddSingleton<ISkillsChampion, RepositorySkillsChampion>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<ChampionViewModel, Champion>();
    cfg.CreateMap<Champion, ChampionViewModel>();

    cfg.CreateMap<SkillsChampionViewModel, SkillsChampion>();
    cfg.CreateMap<SkillsChampion, SkillsChampionViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
