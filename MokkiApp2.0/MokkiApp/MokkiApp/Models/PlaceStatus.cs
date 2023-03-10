using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class PlaceStatus
{
    public int Id { get; set; }

    public int? WorkerId { get; set; }

    public int? PlaceId { get; set; }

    public virtual Place? Place { get; set; }

    public virtual Worker? Worker { get; set; }
}
