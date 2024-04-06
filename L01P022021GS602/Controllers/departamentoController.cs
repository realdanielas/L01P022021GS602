using L01P022021GS602.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01P022021GS602.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class departamentoController : ControllerBase
    {
        private readonly notasContext _notasContexto;

        public departamentoController(notasContext notasContexto)
        {
            _notasContexto = notasContexto;
        }

        //Método para leer todos los registros
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Departadmento> listadoDepartamento = (from d in _notasContexto.departamento
                                            select d).ToList();

            if (listadoDepartamento.Count == 0)
            {
                return NotFound();
            }

            return Ok(listadoDepartamento);
        }
        /*
        //Método para buscar por ID
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Departadmento? departadmento = (from d in _notasContexto.departamento
                                where m.id_materia == id
                                select m).FirstOrDefault();

            if (materia == null)
            {
                return NotFound();

            }

            return Ok(materia);
        }

        //Método para crear o insertar registros
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarMateria([FromBody] Materia materia)
        {
            try
            {
                _notasContexto.materia.Add(materia);
                _notasContexto.SaveChanges();
                return Ok(materia);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para modificar los registros de la tabla
        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarMateria(int id, [FromBody] Materia materiaModificar)
        {
            Materia? materiaActual = (from m in _notasContexto.materia
                                      where m.id_materia == id
                                      select m).FirstOrDefault();

            if (materiaActual == null)
            { return NotFound(); }

            materiaActual.materia_nombre = materiaModificar.materia_nombre;
            materiaActual.unidades_valorativas = materiaModificar.unidades_valorativas;
            materiaActual.estado = materiaModificar.estado;


            _notasContexto.Entry(materiaActual).State = EntityState.Modified;
            _notasContexto.SaveChanges();

            return Ok(materiaModificar);
        }

        //Método para eliminar un registro
        [HttpPut]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarMateria(int id)
        {
            Materia? materia = (from m in _notasContexto.materia
                                where m.id_materia == id
                                select m).FirstOrDefault();

            if (materia == null)
            { return NotFound(); }

            _notasContexto.materia.Attach(materia);
            _notasContexto.materia.Remove(materia);
            _notasContexto.SaveChanges();

            return Ok(materia);

        }*/
    }
}
