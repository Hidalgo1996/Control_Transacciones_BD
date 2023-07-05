using System;
using System.Collections.Generic;

namespace Control_Transacciones_BD3.Models;

public partial class GeneroMusical
{
    public int Id { get; set; }

    public string? NombreGeneroMusical { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
