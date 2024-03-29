﻿using System;
using System.Collections.Generic;

namespace MokkiApp.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
