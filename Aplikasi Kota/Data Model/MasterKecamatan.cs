using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aplikasi_Kota.Data_Model
{
    public class MasterKecamatan: BaseEntities
    {
        public int Id { get; set; }
        public string NamaKecamatan { get; set; }
        public string KodeKecamatan { get; set; }
        public int IdKota { get; set; }

        [ForeignKey("IdKota")]
        public virtual MasterKota? Kota { get; set; }
    }

    public class TableKecamatanConfiguration : IEntityTypeConfiguration<MasterKecamatan>
    {
        public void Configure(EntityTypeBuilder<MasterKecamatan> builder)
        {
            builder.ToTable("Master_Kecamatan");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NamaKecamatan).IsRequired();
            builder.Property(x => x.KodeKecamatan).IsRequired();
            builder.Seed();
        }
    }
    public static class KecamatanBuilderExtension
    {
        public static void Seed(this EntityTypeBuilder<MasterKecamatan> builder)
        {
            builder.HasData(
                new MasterKecamatan
                {
                    Id = 1,
                    NamaKecamatan = "Beji",
                    KodeKecamatan = "DPK",
                    IdKota = 1,
                    IsDeleted = false,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.Now
                },
               new MasterKecamatan
               {
                   Id = 2,
                   NamaKecamatan = "Bojongsari",
                   KodeKecamatan = "BJS",
                   IdKota = 1,
                   IsDeleted = false,
                   ModifiedBy = 1,
                   ModifiedDate = DateTime.Now
               },
               new MasterKecamatan
               {
                   Id = 3,
                   NamaKecamatan = "Cilodong",
                   KodeKecamatan = "CLD",
                   IdKota = 1,
                   IsDeleted = false,
                   ModifiedBy = 1,
                   ModifiedDate = DateTime.Now
               },
               new MasterKecamatan
               {
                   Id = 4,
                   NamaKecamatan = "Beji timur",
                   KodeKecamatan = "BJT",
                   IdKota = 1,
                   IsDeleted = false,
                   ModifiedBy = 1,
                   ModifiedDate = DateTime.Now
               }
                );

        }
    }
}
