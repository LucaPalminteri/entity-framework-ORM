using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class Color
{
    public int Id { get; set; }

    public string Color1 { get; set; } = null!;

    public string? Info { get; set; }
}
