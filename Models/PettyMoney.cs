using System;
using System.Collections.Generic;

namespace ToolBoxBlazor.Models;

public partial class PettyMoney
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public decimal Count { get; set; }
}
