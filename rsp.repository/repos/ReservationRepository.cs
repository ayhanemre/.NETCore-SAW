using System;

public class ReservationRepository : BaseRepository<Reservation, Guid>
{
    public ReservationRepository(ReservationDbContext dbContext) : base(dbContext)
    {
    }
}