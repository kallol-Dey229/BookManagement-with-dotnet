using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int Cid { get; set; }

    public string? Image { get; set; }
}
