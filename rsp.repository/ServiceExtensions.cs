using System;
using Microsoft.Extensions.DependencyInjection;

public static class ThyRepositoryServiceExtension
{
    public static void AddInjectionForThyRepositories(this IServiceCollection services)
    {
        services.AddTransient<IBaseRepository<Reservation, Guid>, ReservationRepository>();
        services.AddTransient<IBaseRepository<User, Guid>, UserRepository>();
    }
}
