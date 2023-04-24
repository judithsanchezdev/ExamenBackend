
using WsApiexamen.Models.Catalog;
using Microsoft.EntityFrameworkCore;

namespace WsApiexamen.Repository
{
    public class clsExamenDBContext: DbContext
    {
        public clsExamenDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //entities
        public DbSet<ExamenModels> tblExamen { get; set; }

    }
}
 