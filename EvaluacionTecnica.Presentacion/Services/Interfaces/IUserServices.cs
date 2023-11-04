using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<UsuarioViewModelResponse>> GetAll();
        Task<UsuarioViewModelResponse> getById(int id);
        Task<bool> Insert(UsuarioViewModelRequest model);
        Task<bool> Update(UserViewModelUpdateReq model);
        Task<bool> Delete(int id);
        Task<bool> LogIn(UserLogInViewModel usuario);
    }
}
