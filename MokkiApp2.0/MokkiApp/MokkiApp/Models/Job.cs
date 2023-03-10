using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Place> Places { get; } = new List<Place>();
}
