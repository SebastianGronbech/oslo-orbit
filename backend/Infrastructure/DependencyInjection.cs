using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OsloOrbit.Domain.Forum;
using OsloOrbit.Infrastructure.Persistence;
using OsloOrbit.Infrastructure.Persistence.Repository;
using OsloOrbit.SharedKernel;

namespace OsloOrbit.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<IPostRepository, PostRepository>();

        return services;
    }
}