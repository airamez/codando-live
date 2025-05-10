using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class QuarterlyOrder
{
    public string CustomerId { get; set; }

    public string CompanyName { get; set; }

    public string City { get; set; }

    public string Country { get; set; }
}
