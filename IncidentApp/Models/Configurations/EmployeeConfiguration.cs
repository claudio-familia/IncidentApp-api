using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Models.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Empleados");

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Position);
            builder.HasOne(x => x.User).WithOne(user => user.Employee).HasForeignKey<Employee>(x => x.UserId);
            builder.HasOne(x => x.Creator);
            builder.HasOne(x => x.Updater);

            builder.Property(x => x.Id).HasColumnName("EmpleadoId");
            builder.Property(x => x.PositionId).HasColumnName("PuestoId");
            builder.Property(x => x.UserId).HasColumnName("UsuarioId");
            builder.Property(x => x.Name).HasColumnName("Nombre").HasMaxLength(100).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("Apellido").HasMaxLength(100).IsRequired();
            builder.Property(x => x.BornDate).HasColumnName("FechaNacimiento");
            builder.Property(x => x.Cedula).HasColumnName("Cedula").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Correo").HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasColumnName("Telefono").HasMaxLength(15);

            builder.Property(x => x.Status).HasColumnName("Estatus").HasMaxLength(2);
            builder.Property(x => x.IsDeleted).HasColumnName("Borrado");
            builder.Property(x => x.CreatedAt).HasColumnName("FechaRegistro");
            builder.Property(x => x.UpdatedAt).HasColumnName("FechaModificacion");
            builder.Property(x => x.CreatedBy).HasColumnName("CreadoPor");
            builder.Property(x => x.UpdatedBy).HasColumnName("ModificadoPor");
        }
    }
}
