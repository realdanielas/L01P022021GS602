using System.ComponentModel.DataAnnotations;

namespace L01P022021GS602.Models
{
    public class Notas
    {
    }

    public class Facultades
    {
        [Key]

        public int id_facultades { get; set; }
        public string? facultad { get; set; }
    }

    public class Materia
    {
        [Key]

        public int id_materia { get; set; }
        public string? materia_nombre { get; set; }
        public int unidades_valorativas { get; set; }
        public char estado { get; set; }
    }

    public class Departadmento
    {
        [Key]

        public int id_departamento { get; set; }
        public string? departamento_nombre { get; set; }
    }
    public class Alumno
    {
        [Key]

        public int id_alumno { get; set; }
        public string? codigo { get; set; }
        public string? nombre { get; set; }
        public string? apellido { get; set; }
        public int dui { get; set; }
        public int estado { get; set; }
    }
}
