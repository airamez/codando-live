using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; }

    public decimal? UnitPrice { get; set; }
}
