using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Models.Configurations
{
    public class SLAConfiguration : IEntityTypeConfiguration<SLA>
    {
        public void Configure(EntityTypeBuilder<SLA> builder)
        {
            builder.ToTable("SLAs");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("SLAId");
            builder.Property(x => x.Description).HasColumnName("Descripcion").IsRequired();
            builder.Property(x => x.Hours).HasColumnName("CantidadHoras").IsRequired();

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro");
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion");
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
