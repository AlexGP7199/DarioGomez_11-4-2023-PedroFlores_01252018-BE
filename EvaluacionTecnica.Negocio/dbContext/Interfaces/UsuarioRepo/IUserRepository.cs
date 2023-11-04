using EvaluacionTecnica.Datos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionTecnica.Negocio.dbContext.Interfaces.UsuarioRepo
{
    public interface IUserRepository : IGenericRepository<Usuario>
    {
        Task<bool> LogIn(Usuario usuario);
    }
}
