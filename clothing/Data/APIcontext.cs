using Microsoft.EntityFrameworkCore;
using clothing.Models;


namespace clothing.Data
{
    public class APIcontext : DbContext
    {
        public DbSet<Clothe> Clothes { get; set; }
        public APIcontext(DbContextOptions<APIcontext> options) :base(options) { }
       
    }
   
    
}
