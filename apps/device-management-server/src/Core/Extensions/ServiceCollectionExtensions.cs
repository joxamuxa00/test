using DeviceManagement.APIs;

namespace DeviceManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IBalloonsService, BalloonsService>();
        services.AddScoped<ICarsService, CarsService>();
        services.AddScoped<IGirlsService, GirlsService>();
        services.AddScoped<ILaptopsService, LaptopsService>();
        services.AddScoped<IMenService, MenService>();
        services.AddScoped<IPhonesService, PhonesService>();
        services.AddScoped<IRemoteControlsService, RemoteControlsService>();
        services.AddScoped<IStudentsService, StudentsService>();
    }
}
