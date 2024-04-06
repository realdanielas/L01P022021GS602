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
        
        //Método para buscar por ID
        [HttpGet]
        [Route("GetById/{id}")]

        public IActionResult Get(int id)
        {
            Departadmento? departadmento = (from d in _notasContexto.departamento
                                where d.id_departamento == id
                                select d).FirstOrDefault();

            if (departadmento == null)
            {
                return NotFound();

            }

            return Ok(departadmento);
        }

        //Método para crear o insertar registros
        [HttpPost]
        [Route("Add")]

        public IActionResult GuardarDepartamento ([FromBody] Departadmento departamento)
        {
            try
            {
                _notasContexto.departamento.Add(departamento);
                _notasContexto.SaveChanges();
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Método para modificar los registros de la tabla
        [HttpPut]
        [Route("Actualizar/{id}")]

        public IActionResult ActualizarDepartamento(int id, [FromBody] Departadmento departamentoModificar)
        {
            Departadmento? departamentoActual = (from d in _notasContexto.departamento
                                      where d.id_departamento == id
                                      select d).FirstOrDefault();

            if (departamentoActual == null)
            { return NotFound(); }

            departamentoActual.departamento_nombre = departamentoModificar.departamento_nombre;


            _notasContexto.Entry(departamentoActual).State = EntityState.Modified;
            _notasContexto.SaveChanges();

            return Ok(departamentoModificar);
        }

        //Método para eliminar un registro
        [HttpPut]
        [Route("Eliminar/{id}")]
        public IActionResult EliminarDepartamento(int id)
        {
            Departadmento? departadmento = (from d in _notasContexto.departamento
                                where d.id_departamento == id
                                select d).FirstOrDefault();

            if (departadmento == null)
            { return NotFound(); }

            _notasContexto.departamento.Attach(departadmento);
            _notasContexto.departamento.Remove(departadmento);
            _notasContexto.SaveChanges();

            return Ok(departadmento);

        }
    }
}
