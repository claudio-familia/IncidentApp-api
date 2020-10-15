using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Models.Configurations
{
    public class IncidentHistoryConfiguration : IEntityTypeConfiguration<IncidentHistory>
    {
        public void Configure(EntityTypeBuilder<IncidentHistory> builder)
        {
            builder.ToTable("HistorialIncidentes");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Incident);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("HistorialIncidenteId");
            builder.Property(x => x.IncidentId).HasColumnName("IncidenteId").IsRequired();
            builder.Property(x => x.Comment).HasColumnName("Comentario").HasMaxLength(500).IsRequired();

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro");
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion");
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
