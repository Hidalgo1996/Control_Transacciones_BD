using System;
using System.Collections.Generic;

namespace Control_Transacciones_BD3.Models;

public partial class Nacionalidad
{
    public int Id { get; set; }

    public string? NombreNacionalidad { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
