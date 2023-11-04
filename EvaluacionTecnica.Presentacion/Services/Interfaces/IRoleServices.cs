using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.Services.Interfaces
{
    public interface IRoleServices
    {
        Task<List<RoleViewModelReponse>> GetAll();
        Task<RoleViewModelReponse> getById(int id);
        Task<bool> Insert(RoleViewModelRequest model);
        Task<bool> Update(RoleViewModelRequest model);
        Task<bool> Delete(int id);
    }
}
