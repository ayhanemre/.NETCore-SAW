public interface IEntity<T>
{
    T Id { get; set; }

    bool isDeleted{get;set;}

}