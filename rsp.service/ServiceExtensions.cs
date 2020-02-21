using System;
using Microsoft.Extensions.DependencyInjection;

public static class ThyServicesServiceExtension
{
    public static void AddInjectionForThyServices(this IServiceCollection services)
    {
        services.AddTransient<IBaseService<Reservation, Guid>, ReservationService>();
        services.AddTransient<IBaseService<User, Guid>, UserService>();
    }
}
