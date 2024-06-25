using Microsoft.EntityFrameworkCore;

namespace Aplikasi_Kota.Data_Model
{
    public class KotaDbContext : DbContext
    {
        public KotaDbContext(DbContextOptions<KotaDbContext> options) : base(options)
        {
        }
        public DbSet<MasterKota> Kotas { get; set; }
        public DbSet<MasterKecamatan> Kecamatans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TableKotaConfiguration());
            modelBuilder.ApplyConfiguration(new TableKecamatanConfiguration());
        }
    }
}