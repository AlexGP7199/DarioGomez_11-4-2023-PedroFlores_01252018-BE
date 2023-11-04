using AutoMapper;
using EvaluacionTecnica.Datos.Models;
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
    public class UsuarioService : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UsuarioService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<UsuarioViewModelResponse>> GetAll()
        {
            var data = await _repository.GetAll();
            var userList = _mapper.Map<List<UsuarioViewModelResponse>>(data);
            return userList;
        }

        public async Task<UsuarioViewModelResponse> getById(int id)
        {
            var data = await _repository.getById(id);
            var user = _mapper.Map<UsuarioViewModelResponse>(data);
            return user;
        }

        public async Task<bool> Insert(UsuarioViewModelRequest model)
        {
            var data = _mapper.Map<Usuario>(model);
            return await _repository.Insert(data);
        }

        public async Task<bool> LogIn(UserLogInViewModel usuario)
        {
            var user = _mapper.Map<Usuario>(usuario);
            return await _repository.LogIn(user);
        }

        public async Task<bool> Update(UsuarioViewModelRequest model)
        {
            var data = _mapper.Map<Usuario>(model);
            return await _repository.Update(data);

        }
    }
}
