using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response
{
    public class UsuarioViewModelResponse
    {
        public int Id { get; set; }

        public int? RoleId { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
        public string? UsuarioNombre { get; set; }
        public string? Pasword { get; set; }
        public string? Cedula { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
