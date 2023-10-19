using gym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriaController : ControllerBase
    {

        private readonly gymContext _gymContext;

        public categoriaController(gymContext gymContexto)
        {
            _gymContext = gymContexto;
        }


        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get()
        {
            List<categoria> listadoCategorias = _gymContext.categoria.ToList();

            if (listadoCategorias.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoCategorias);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] categoria usuario)
        {

            try
            {
                _gymContext.categoria.Add(usuario);
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
        [Route("deleteCategoria/{id}")]
        public void DeleteCategoria(int id)
        {
            var categoria = _gymContext.Set<categoria>().FirstOrDefault(u => u.id_categoria == id);
            if (categoria != null)
            {
                _gymContext.Set<categoria>().Remove(categoria);
                _gymContext.SaveChanges();
            }
        }
        #endregion


    }
}
