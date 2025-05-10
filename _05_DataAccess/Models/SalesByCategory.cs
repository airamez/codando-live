using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class SalesByCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string ProductName { get; set; }

    public decimal? ProductSales { get; set; }
}
