using ZooAPI.Data;
using ZooAPI.Data.Contracts;
using ZooAPI.Data.Models;

namespace AnimalAPI.Services;

public static class ServiceExtenxions
{
    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Zoo>, ZooRepository>();
    }
}