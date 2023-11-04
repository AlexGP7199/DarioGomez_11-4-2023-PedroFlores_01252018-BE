using System;
using System.Collections.Generic;

namespace EvaluacionTecnica.Datos.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Cedula { get; set; }

    public string? UsuarioNombre { get; set; }

    public string? Pasword { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? UsuarioTransaccion { get; set; }

    public DateTime? FechaTransaccion { get; set; }

    public virtual Role? Role { get; set; }
}
