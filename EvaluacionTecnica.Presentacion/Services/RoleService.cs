using AutoMapper;
using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Negocio.dbContext.Interfaces;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.RoleRepo;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.UsuarioRepo;
using EvaluacionTecnica.Presentacion.Services.Interfaces;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Presentacion.Services
{
    public class RoleService : IRoleServices
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;
        public RoleService(IMapper mapper, IRoleRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<RoleViewModelReponse>> GetAll()
        {
            var listRole = await _repository.GetAll();
            var data = _mapper.Map<List<RoleViewModelReponse>>(listRole);
            return data;
        }

        public async Task<RoleViewModelReponse> getById(int id)
        {
            var role = await _repository.getById(id);
            var data = _mapper.Map<RoleViewModelReponse>(role);
            return data;
        }

        public async Task<bool> Insert(RoleViewModelRequest model)
        {
            var data = _mapper.Map<Role>(model);
            return await _repository.Insert(data);
        }

        public async Task<bool> Update(RoleViewModelRequest model)
        {
            var data = _mapper.Map<Role>(model);
            return await _repository.Update(data);
        }
    }
}
