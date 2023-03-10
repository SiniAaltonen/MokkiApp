using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public string? Diet { get; set; }

    public string Interests { get; set; } = null!;

    public int? SeasonId { get; set; }

    public int? WorkerId { get; set; }

    public string? BlobUrl { get; set; }

    public virtual Season? Season { get; set; }

    public virtual Worker? Worker { get; set; }
}
