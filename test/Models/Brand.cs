using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public bool BrandActive { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
