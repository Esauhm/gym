using gym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usuariosController : ControllerBase
    {

        private readonly gymContext _gymContext;

        public usuariosController(gymContext gymContexto)
        {
            _gymContext = gymContexto;
        }


        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<usuarios> listadoUsuarios = _gymContext.usuarios.ToList();

            if (listadoUsuarios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoUsuarios);
        }


        #endregion

        #region Login
        [HttpPost("login")]
        public ActionResult GetLogin([FromBody] UsuarioLoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Los datos de inicio de sesión son nulos o incorrectos.");
            }

            usuarios usuario = _gymContext.usuarios.FirstOrDefault(u => u.correo == request.Correo && u.passwords == request.Password);

            if (usuario == null)
            {
                return NotFound("No se encontró un usuario con las credenciales proporcionadas.");
            }

            // Aquí puedes devolver el objeto usuario encontrado
            return Ok(usuario);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] usuarios usuario)
        {

            try
            {
                _gymContext.usuarios.Add(usuario);
                _gymContext.SaveChanges();

                return Ok(usuario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteUsuarios/{id}")]
        public void DeleteCategoria(int id)
        {
            var usuarios = _gymContext.Set<usuarios>().FirstOrDefault(u => u.id_usuario == id);
            if (usuarios != null)
            {
                _gymContext.Set<usuarios>().Remove(usuarios);
                _gymContext.SaveChanges();
            }
        }
        #endregion
    }
}
