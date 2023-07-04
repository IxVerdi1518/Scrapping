using System;
using System.Collections.Generic;

namespace PruebaScra.Models;

public partial class Compra
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Precio { get; set; }

    public DateTime FechaCompra { get; set; }
}
