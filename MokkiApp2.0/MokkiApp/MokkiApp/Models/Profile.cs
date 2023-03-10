using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Profile
{
    public string? Avatar { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? WorkerId { get; set; }

    public virtual Worker? Worker { get; set; }
}
