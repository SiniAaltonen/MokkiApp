using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Season
{
    public int Id { get; set; }

    public string Season1 { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();

    public virtual ICollection<Work> Works { get; } = new List<Work>();
}
