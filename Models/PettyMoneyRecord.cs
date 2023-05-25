using System;
using System.Collections.Generic;

namespace ToolBoxBlazor.Models;

public partial class PettyMoneyRecord
{
    public int Id { get; set; }

    /// <summary>
    /// 对应petty_money表中的id
    /// </summary>
    public int TypeId { get; set; }

    /// <summary>
    /// 对应coffee_type表中的id，没有则为空
    /// </summary>
    public int? CoffeeTypeId { get; set; }

    public string? VideoName { get; set; }

    public DateTime Date { get; set; }

    public decimal Count { get; set; }
}
