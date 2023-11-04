using EvaluacionTecnica.Presentacion.Services.Interfaces;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet("allRoles")]
        public async Task<IActionResult> getAllRoles()
        {
            try
            {
                var data = await _roleServices.GetAll();
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("getById")]
        public async Task<IActionResult> getRoleById(int id)
        {
            try
            {
                var data = await _roleServices.getById(id);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("CreateNewRole")]
        public async Task<IActionResult> createNewRole([FromBody] RoleViewModelRequest roleDto)
        {
            try
            {
                var data = await _roleServices.Insert(roleDto);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateRole")]
        public async Task<IActionResult> updateRole([FromBody] RoleViewModelRequest roleDto)
        {
            try
            {
                var data = await _roleServices.Update(roleDto);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> deleteRole(int id)
        {
            try
            {
                var data = await _roleServices.Delete(id);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
