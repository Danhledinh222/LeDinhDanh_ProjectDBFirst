using System;
using System.Collections.Generic;

namespace DBFirst.Models;

public partial class ThietBi
{
    public int Mathietbi { get; set; }

    public string? Tenthietbi { get; set; }

    public int? Soluong { get; set; }

    public decimal? Dongia { get; set; }

    public int? Manhom { get; set; }
}
