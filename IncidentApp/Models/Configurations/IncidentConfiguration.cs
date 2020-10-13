using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Models.Configurations
{
    public class IncidentConfiguration : IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidentes");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Priority);
            builder.HasOne(x => x.Department);
            builder.HasOne(x => x.ReportedUser);
            builder.HasOne(x => x.AssignedUser);
            builder.HasMany(x => x.IncidentHistory);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("IncidenteId");
            builder.Property(x => x.ReportedUserId).HasColumnName("UsuarioReportaId").IsRequired();
            builder.Property(x => x.AssignedUserId).HasColumnName("UsuarioAsignadoId");
            builder.Property(x => x.PriorityId).HasColumnName("PrioridadId");
            builder.Property(x => x.DepartmentId).HasColumnName("DepartamentoId");

            builder.Property(x => x.Title).HasColumnName("Titulo").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasColumnName("Descripcion").IsRequired();
            builder.Property(x => x.ClosedDate).HasColumnName("FechaCierre").HasColumnType("datetimeoffset");
            builder.Property(x => x.ClosedComment).HasColumnName("ComentarioCierre").HasMaxLength(500);

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
