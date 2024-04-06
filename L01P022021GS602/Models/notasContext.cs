using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace L01P022021GS602.Models
{
    public class notasContext : DbContext
    {
        public notasContext(DbContextOptions<notasContext> options) : base(options)
        {
        }

        public DbSet<Facultades> facultades { get; set; }
        public DbSet<Materia> materia { get; set; }
        public DbSet<Departadmento> departamento { get; set; }
        public DbSet<Alumno> alumno { get; set; }
    }
}
