using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Place
{
    public int Id { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int? JobId { get; set; }

    public virtual Job? Job { get; set; }

    public virtual ICollection<PlaceStatus> PlaceStatuses { get; } = new List<PlaceStatus>();
}
