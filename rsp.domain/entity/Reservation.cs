using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Reservation : IEntity<Guid>
{
    public Guid UserId { get; set; }

    // [ForeignKey("UserId")]
    public User User{get;set;}

    public int RoomNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid Id { get; set; }
    public bool isDeleted { get; set; }
    public bool isActive { get; set; }
}