using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; }

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
