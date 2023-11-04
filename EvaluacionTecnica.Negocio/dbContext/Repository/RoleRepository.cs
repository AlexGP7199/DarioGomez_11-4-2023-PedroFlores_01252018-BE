using EvaluacionTecnica.Datos.Models;
using EvaluacionTecnica.Negocio.dbContext.Interfaces;
using EvaluacionTecnica.Negocio.dbContext.Interfaces.RoleRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Negocio.dbContext.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EvaluacionTecnicaDbContext _dbContext;
        public RoleRepository(EvaluacionTecnicaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Role>> GetAll()
        {
            var data = await _dbContext.Roles.ToListAsync();
            return data;
        }

        public async Task<Role> getById(int id)
        {
            var roleExist = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (roleExist == null)
            {
                throw new Exception("Este role no existe");
            }
            else
            {
                return roleExist;
            }
        }

        public async Task<bool> Insert(Role model)
        {
            var data = await _dbContext.Roles.FirstOrDefaultAsync(x=>x.Id == model.Id || x.Nombre == model.Nombre);
            if(data == null)
            {
                _dbContext.Roles.Add(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new Exception("Ya existe un role con dicho id/nombre");
            }
        }

        public async Task<bool> Update(Role model)
        {
            var data = await _dbContext.Roles.FirstOrDefaultAsync(x=> x.Id == model.Id);
            if(data == null)
            {
                throw new Exception("Ese rol no existe para editar");
            }   
            else
            {
                data.Nombre = model.Nombre;
                _dbContext.Update(data);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var roleToEliminate = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (roleToEliminate != null)
            {
                var roleQuantityInPeople = _dbContext.Usuarios.Count(x => x.RoleId == id);
                if (roleQuantityInPeople == 0)
                {
                    _dbContext.Roles.Remove(roleToEliminate);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("Existen personas con este role asignado");
                }
            }
            else
            {
                throw new Exception("Ese rol no existe");
            }
        }

    }
}
