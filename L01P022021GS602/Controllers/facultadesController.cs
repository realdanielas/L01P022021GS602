using L01P022021GS602.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01P022021GS602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class notasController : ControllerBase
    {
        private readonly notasContext _notasContexto;

        public notasController(notasContext notasContexto)
        {
            _notasContexto = notasContexto;
        }

        //Método para leer todos los registros
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Facultades> listadoFacultades = (from e in _notasContexto.facultades
                                                  select e).ToList();

            if (listadoFacultades.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoFacultades);
        }

        //Método para buscar por ID
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Facultades? facultades = (from f in _notasContexto.facultades
                                      where f.id_facultades == id
                               select f).FirstOrDefault();

            if (facultades == null)
            {
                return NotFound();

            }

            return Ok(facultades);
        }

        //Método para crear o insertar registros
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarFacultades([FromBody] Facultades facultades)
        {
            try
            {
                _notasContexto.facultades.Add(facultades);
                _notasContexto.SaveChanges();
                return Ok(facultades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para modificar los registros de la tabla
        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarFacultades(int id, [FromBody] Facultades facultadesModificar)
        {
            Facultades? facultadActual = (from f in _notasContexto.facultades
                                     where f.id_facultades == id
                                     select f).FirstOrDefault();

            if (facultadActual == null)
            { return NotFound(); }

            facultadActual.facultad = facultadesModificar.facultad;


            _notasContexto.Entry(facultadActual).State = EntityState.Modified;
            _notasContexto.SaveChanges();

            return Ok(facultadesModificar);
        }

        //Método para eliminar un registro
        [HttpPut]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarFacultades(int id)
        {
            Facultades? facultades = (from f in _notasContexto.facultades
                               where f.id_facultades == id
                               select f).FirstOrDefault();

            if (facultades == null)
            { return NotFound(); }

            _notasContexto.facultades.Attach(facultades);
            _notasContexto.facultades.Remove(facultades);
            _notasContexto.SaveChanges();

            return Ok(facultades);

        }
    }
}
