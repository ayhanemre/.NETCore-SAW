using System;
using System.Collections.Generic;

public class User : IEntity<Guid>
{
    public string UserName { get; set; }
    public string Phone { get; set; }
    public Guid Id { get; set; }
    public bool isDeleted { get; set; }
    public ICollection<Reservation> Reservations{get;set;}
}