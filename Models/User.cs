using System;
using System.Collections.Generic;

namespace EntityFramework.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public byte[] Key { get; set; } = null!;

    public DateTime Date { get; set; }
}
