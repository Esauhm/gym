using gym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ejerciciosController : ControllerBase
    {

        private readonly gymContext _gymContext;

        public ejerciciosController(gymContext gymContexto) 
        {
            _gymContext = gymContexto;
        }

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetEjerciciosAll")]
        public ActionResult Get()
        {
            List<ejercicios> listadoEjercicios = _gymContext.ejercicios.ToList();

            if (listadoEjercicios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEjercicios);
        }
        #endregion


        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAll")]
        public ActionResult Get([FromQuery] int categoriaId)
        {
            List<ejercicios> listadoEjercicios = _gymContext.ejercicios.Where(e => e.id_categoria == categoriaId).ToList();

            if (listadoEjercicios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEjercicios);
        }
        #endregion

        #region GET_ALL - GET
        [HttpGet]
        [Route("GetAllidEjer")]
        public ActionResult GetEjer([FromQuery] int ejercicioid)
        {
            List<ejercicios> listadoEjercicios = _gymContext.ejercicios.Where(e => e.id_ejercicio == ejercicioid).ToList();

            if (listadoEjercicios.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoEjercicios);
        }
        #endregion

        #region AGREGAR - POST
        [HttpPost]
        [Route("add")]
        public IActionResult crear([FromBody] ejercicios ejerciciosT)
        {

            try
            {

                _gymContext.ejercicios.Add(ejerciciosT);
                _gymContext.SaveChanges();

                return Ok(ejerciciosT);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion

        #region ACTUALIZAR - POST

        [HttpPut]
        [Route("Actualizar/{id}")]
        public IActionResult actualizar(int id, [FromBody] ejercicios ejerciciosT)
        {
            ejercicios? estadoE = _gymContext.ejercicios.Find(id);

            if (estadoE == null)
            {
                return NotFound();
            }

            estadoE.nombre = ejerciciosT.nombre;
            estadoE.imagen_url = ejerciciosT.imagen_url;
            estadoE.descripcion = ejerciciosT.descripcion;
            estadoE.id_categoria = ejerciciosT.id_categoria;



            _gymContext.Entry(estadoE).State = EntityState.Modified;
            _gymContext.SaveChanges();

            return Ok(estadoE);

        }

        #endregion

        #region ELIMINAR - DELETE 
        [HttpDelete]
        [Route("deleteEjercicio/{id}")]
        public void DeleteCarrito(int id)
        {
            var ejer = _gymContext.Set<ejercicios>().FirstOrDefault(u => u.id_ejercicio == id);
            if (ejer != null)
            {
                _gymContext.Set<ejercicios>().Remove(ejer);
                _gymContext.SaveChanges();
            }
        }
        #endregion

    }
}
