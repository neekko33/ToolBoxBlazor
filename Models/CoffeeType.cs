using System;
using System.Collections.Generic;

namespace ToolBoxBlazor.Models;

public partial class CoffeeType
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public decimal Price { get; set; }
}
