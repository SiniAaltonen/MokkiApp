using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Work
{
    public int Id { get; set; }

    public string WorkName { get; set; } = null!;

    public string Duration { get; set; } = null!;

    public string Importancy { get; set; } = null!;

    public string Equipment { get; set; } = null!;

    public int? SeasonId { get; set; }

    public virtual Season? Season { get; set; }

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
