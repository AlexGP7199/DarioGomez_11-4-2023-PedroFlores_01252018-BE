using AutoMapper;
using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response;


namespace EvaluacionTecnica.Presentacion.ViewModel.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleViewModelReponse>();
            CreateMap<RoleViewModelReponse, Role>();
            CreateMap<Role, RoleViewModelRequest>();
            CreateMap<RoleViewModelRequest, Role>();
            CreateMap<RoleViewModelRequest, Role>();
            
        }
    }
}
