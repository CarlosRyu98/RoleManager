public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configuración del DbContext con SQL Server
        builder.Services.AddDbContext<RoleManagerDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
        builder.Services.AddAutoMapper(typeof(CampaignProfile));

        builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();
        builder.Services.AddAutoMapper(typeof(CharacterProfile));

        builder.Services.AddScoped<IDomainRepository, DomainRepository>();
        builder.Services.AddAutoMapper(typeof(DomainProfile));

        builder.Services.AddScoped<IFactionRepository, FactionRepository>();
        builder.Services.AddAutoMapper(typeof(FactionProfile));

        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddAutoMapper(typeof(LocationProfile));

        builder.Services.AddScoped<IQuestRepository, QuestRepository>();
        builder.Services.AddScoped<IQuestStageRepository, QuestStageRepository>();
        builder.Services.AddAutoMapper(typeof(QuestProfile));

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
    }
}