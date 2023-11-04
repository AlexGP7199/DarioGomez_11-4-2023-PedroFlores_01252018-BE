using EvaluacionTecnica.Presentacion.Services.Interfaces;
using EvaluacionTecnica.Presentacion.ViewModel.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UsuarioController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("AllUsers")]
        public async Task<IActionResult> getAllUsers()
        {
            try
            {
                var data = await _userServices.GetAll();
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("UserById")]
        public async Task<IActionResult> getUserById(int id)
        {
            try
            {
                var data = await _userServices.getById(id);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> createNewUser([FromBody] UsuarioViewModelRequest userDto)
        {
            try
            {
                var data = await _userServices.Insert(userDto);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> logIn([FromBody] UserLogInViewModel userDto)
        {
            try
            {
                var data = await _userServices.LogIn(userDto);
                return Ok(data);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("UpdateAnUser")]
        public async Task<IActionResult> updateUser([FromBody] UsuarioViewModelRequest userDto)
        {
            try
            {
                var data = await _userServices.Update(userDto);
                return Ok(data);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> deleteUser(int id)
        {
            try
            {
                var data = await _userServices.Delete(id);
                return Ok(data);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
