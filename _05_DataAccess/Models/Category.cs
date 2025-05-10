using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public byte[] Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
