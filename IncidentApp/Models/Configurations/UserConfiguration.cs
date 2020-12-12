using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace IncidentApp.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {        
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Usuarios");
            
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Employee);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("EmpleadoId");
            builder.Property(x => x.Username).HasColumnName("NombreUsuario").IsRequired();
            builder.Property(x => x.Password).HasColumnName("Contrasena").IsRequired();

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro").HasColumnType("datetime");
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion").HasColumnType("datetime");
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
