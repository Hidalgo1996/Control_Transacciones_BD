using System;
using System.Collections.Generic;

namespace Control_Transacciones_BD3.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Estado { get; set; }

    public int? IdGeneroMusical { get; set; }

    public int? IdNacionalidad { get; set; }

    public virtual GeneroMusical? IdGeneroMusicalNavigation { get; set; }

    public virtual Nacionalidad? IdNacionalidadNavigation { get; set; }
}
