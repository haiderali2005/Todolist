using Microsoft.EntityFrameworkCore;

namespace WebApplication24.Models
{
    public class Mycon :DbContext
    {
        public Mycon(DbContextOptions op):base(op)
        {
            
        }
        public DbSet<Todolist> tbl_todolist {  get; set; }
    }
}
