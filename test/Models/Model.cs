using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models;

public partial class Model
{
    public int ModelId { get; set; }

    public string ModelName { get; set; } = null!;

    public int ModelBrandId { get; set; }

    public bool ModelActive { get; set; }
    [BindNever]
    public virtual Brand ModelBrand { get; set; } = null!;
}
