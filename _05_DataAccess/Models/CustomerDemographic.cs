using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class CustomerDemographic
{
    public string CustomerTypeId { get; set; }

    public string CustomerDesc { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
