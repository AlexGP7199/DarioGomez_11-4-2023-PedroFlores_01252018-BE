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
            CreateMap<Role, RoleViewModelReponse>().ReverseMap();
            
            CreateMap<Role, RoleViewModelRequest>().ReverseMap();
  
            CreateMap<Role, RoleViewModelUpdateReq>().ReverseMap();
            
        }
    }
}
