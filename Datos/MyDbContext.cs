using Microsoft.EntityFrameworkCore;
using Tarea6.Modelos;

namespace Tarea6.Datos
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Agente> Agentes { get; set; }
    }
}
