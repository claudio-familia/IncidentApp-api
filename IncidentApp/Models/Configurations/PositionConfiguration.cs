using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Models.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Puestos");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Department);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("PuestoId");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartamentoId").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Nombre").HasMaxLength(100).IsRequired();

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
