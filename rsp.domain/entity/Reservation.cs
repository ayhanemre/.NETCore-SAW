using System;

public class Reservation : IEntity<Guid>
{
    public Guid UserId { get; set; }
    public int RoomNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid Id { get; set; }
    public bool isDeleted { get; set; }
}