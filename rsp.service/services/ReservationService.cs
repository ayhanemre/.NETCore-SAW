using System;

public class ReservationService : BaseService<Reservation, Guid>
{
    public ReservationService(IBaseRepository<Reservation, Guid> repository) : base(repository)
    {
    }
}