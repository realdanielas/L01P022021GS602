using L01P022021GS602.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01P022021GS602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class alumnoController : ControllerBase
    {
        private readonly notasContext _notasContexto;

        public alumnoController(notasContext notasContexto)
        {
            _notasContexto = notasContexto;
        }

        //Método para leer todos los registros
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Alumno> listadoAlumno = (from a in _notasContexto.alumno
                                                       select a).ToList();

            if (listadoAlumno.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoAlumno);
        }

        //Método para buscar por ID
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Alumno? alumno = (from a in _notasContexto.alumno
                                            where a.id_alumno == id
                                            select a).FirstOrDefault();

            if (alumno == null)
            {
                return NotFound();

            }

            return Ok(alumno);
        }

        //Método para crear o insertar registros
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarAlumno([FromBody] Alumno alumno)
        {
            try
            {
                _notasContexto.alumno.Add(alumno);
                _notasContexto.SaveChanges();
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para modificar los registros de la tabla
        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarAlumno(int id, [FromBody] Alumno alumnoModificar)
        {
            Alumno? alumnoActual = (from a in _notasContexto.alumno
                                                 where a.id_alumno == id
                                                 select a).FirstOrDefault();

            if (alumnoActual == null)
            { return NotFound(); }

            alumnoActual.codigo = alumnoModificar.codigo;
            alumnoActual.nombre = alumnoModificar.nombre;
            alumnoActual.apellido = alumnoModificar.apellido;
            alumnoActual.dui = alumnoActual.dui;
            alumnoActual.estado = alumnoModificar.estado;


            _notasContexto.Entry(alumnoActual).State = EntityState.Modified;
            _notasContexto.SaveChanges();

            return Ok(alumnoModificar);
        }

        //Método para eliminar un registro
        [HttpPut]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarAlumno(int id)
        {
            Alumno? alumno = (from a in _notasContexto.alumno
                                            where a.id_alumno == id
                                            select a).FirstOrDefault();

            if (alumno == null)
            { return NotFound(); }

            _notasContexto.alumno.Attach(alumno);
            _notasContexto.alumno.Remove(alumno);
            _notasContexto.SaveChanges();

            return Ok(alumno);

        }
    }
}
