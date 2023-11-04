using AutoMapper;
using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.ViewModel.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioViewModelResponse>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModelRequest>().ReverseMap();
            CreateMap<Usuario, UserLogInViewModel>().ReverseMap();
        }
    }
}
