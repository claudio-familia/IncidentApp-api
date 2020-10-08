using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentApp.Models.Configurations
{
    public class SLAConfiguration : IEntityTypeConfiguration<SLA>
    {
        public void Configure(EntityTypeBuilder<SLA> builder)
        {
            builder.ToTable("SLAs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("SLAId");
            builder.Property(x => x.Description).HasColumnName("Descripcion");
            builder.Property(x => x.Hours).HasColumnName("CantidadHoras");

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion").HasColumnType("datetimeoffset"); ;
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
