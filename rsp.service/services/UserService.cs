using System;

public class UserService : BaseService<User, Guid>
{
    public UserService(IBaseRepository<User, Guid> repository) : base(repository)
    {
    }
}