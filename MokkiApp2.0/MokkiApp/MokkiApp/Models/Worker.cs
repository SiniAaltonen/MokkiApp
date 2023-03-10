using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Zipcode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? WorkId { get; set; }

    public virtual ICollection<PlaceStatus> PlaceStatuses { get; } = new List<PlaceStatus>();

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual Work? Work { get; set; }
}
