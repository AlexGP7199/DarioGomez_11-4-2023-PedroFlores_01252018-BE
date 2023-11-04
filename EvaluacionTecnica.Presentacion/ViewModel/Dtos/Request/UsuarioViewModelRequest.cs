using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request
{
    public class UsuarioViewModelRequest
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? pasword { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
