using Microsoft.EntityFrameworkCore;
using S.I_AgenciaViajes.Models;

namespace S.I_AgenciaViajes.Contexto
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions options) : base(options) 
        {
        
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
