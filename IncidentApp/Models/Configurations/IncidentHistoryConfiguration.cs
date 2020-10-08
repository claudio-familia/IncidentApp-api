using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Configurations
{
    public class IncidentHistoryConfiguration : IEntityTypeConfiguration<IncidentHistory>
    {
        public void Configure(EntityTypeBuilder<IncidentHistory> builder)
        {
            builder.ToTable("HistorialIncidentes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("HistorialIncidenteId");
            builder.Property(x => x.IncidentId).HasColumnName("IncidenteId");
            builder.Property(x => x.Comment).HasColumnName("Comentario").HasMaxLength(500);            

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
