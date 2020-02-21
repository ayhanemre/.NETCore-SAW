using System;

public class UserRepository : BaseRepository<User, Guid>
{
    public UserRepository(ReservationDbContext dbContext) : base(dbContext)
    {
    }
}