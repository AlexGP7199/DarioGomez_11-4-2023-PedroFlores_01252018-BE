using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Negocio.dbContext.Interfaces;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.UsuarioRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Negocio.dbContext.Repository
{
    public class UsuarioRepository : IUserRepository
    {
        private readonly EvaluacionTecnicaDbContext _dbContext;
        public UsuarioRepository(EvaluacionTecnicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
      

        public async Task<List<Usuario>> GetAll()
        {
            var data = await _dbContext.Usuarios.ToListAsync();
            return data;
        }

        public async Task<Usuario> getById(int id)
        {
            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("No se encuentra dicho usuario");
            }
            else
            {
                return user;
            }
        }

        public async Task<bool> Insert(Usuario model)
        {
            var userExist = await _dbContext.Usuarios.FirstOrDefaultAsync(x=> x.Id == model.Id);
            if(userExist == null)
            {
                _dbContext.Usuarios.Add(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Ese usuario ya existe");
            }
        }

        public async Task<bool> Update(Usuario model)
        {
            var data = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == model.Id);
            if(data == null)
            {
                throw new Exception("Ese usuario no existe");
            }
            else
            {
                data.RoleId = model.RoleId;
                data.Nombre = model.Nombre;
                data.Apellido = model.Apellido;
                data.UsuarioNombre = model.UsuarioNombre;
                data.Pasword = model.Pasword;
                data.Cedula = model.Cedula;
                data.FechaNacimiento = model.FechaNacimiento;
                _dbContext.Usuarios.Update(data);

                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> Delete(int id)
        {
            var data = await _dbContext.Usuarios.FirstOrDefaultAsync(x=> x.Id == id);
            if(data == null)
            {
                throw new Exception(" Ese usuario no existe");
            }
            else
            {
                _dbContext.Usuarios.Remove(data); 
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> LogIn(Usuario usuario)
        {
            var data = await _dbContext.Usuarios.Where(x => x.UsuarioNombre == usuario.UsuarioNombre && x.Pasword == usuario.Pasword).FirstOrDefaultAsync();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
