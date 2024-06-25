using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplikasi_Kota.Data_Model
{
    public class MasterKota: BaseEntities
    {
        public int Id { get; set; }
        public string NamaKota { get; set; }
        public string KodeKota { get; set; }
    }

    public class TableKotaConfiguration : IEntityTypeConfiguration<MasterKota>
    {
        public void Configure(EntityTypeBuilder<MasterKota> builder)
        {
            builder.ToTable("Master_Kota");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NamaKota).IsRequired();
            builder.Property(x => x.KodeKota).IsRequired();
            builder.Seed();
        }
    }
    public static class KotaBuilderExtension
    {
        public static void Seed(this EntityTypeBuilder<MasterKota> builder)
        {
            builder.HasData(
                new MasterKota
                {
                    Id=1,
                    NamaKota="Depok",
                    KodeKota="DPK",
                    IsDeleted=false,
                    ModifiedBy=1,
                    ModifiedDate=DateTime.Now
                }, 
                new MasterKota
                {
                    Id = 2,
                    NamaKota = "Jakarta Utara",
                    KodeKota = "DPK",
                    IsDeleted = false,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                },
                new MasterKota
                {
                    Id = 3,
                    NamaKota = "Jakarta Selatan",
                    KodeKota = "DPK",
                    IsDeleted = false,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                },
                
                new MasterKota
                {
                    Id = 4,
                    NamaKota = "Jakarta Barat",
                    KodeKota = "DPK",
                    IsDeleted = false,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                }
                );
                
        }
    }
}