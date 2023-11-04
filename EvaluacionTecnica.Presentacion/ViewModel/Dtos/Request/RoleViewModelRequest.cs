using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request
{
    public class RoleViewModelRequest
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
    }
}
