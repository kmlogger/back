using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Cold.FluentMapping
{
    public class AppMapping : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            // Nome da tabela
            builder.ToTable("Apps");

            // Chave primária
            builder.HasKey(a => a.Id);

            // Propriedades
            builder.Property(a => a.Id)
                .HasColumnName("Id")
                .HasColumnType("UUID")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(a => a.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasColumnType("DateTime")
                .HasDefaultValueSql("now()");

            builder.Property(a => a.UpdatedDate)
                .HasColumnName("UpdatedDate")
                .HasColumnType("DateTime")
                .IsRequired()
                .HasDefaultValueSql("now()");

            builder.Property(a => a.DeletedDate)
                .HasColumnName("DeletedDate")
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(a => a.Environment)
                .HasColumnName("Environment")
                .HasColumnType("String");

            builder.Property(a => a.Active)
                .HasColumnName("Active")
                .HasColumnType("UInt8");

            // Mapeamento do Value Object UniqueName
            builder.OwnsOne(a => a.Name, name =>
            {
                name.Property(n => n.Name)
                    .HasColumnName("Name")
                    .HasColumnType("String")
                    .HasMaxLength(100);
            });

            // Relacionamento com Category
            builder.HasOne(a => a.Category)
                .WithMany(c => c.Apps)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacionamento com LogEntry
            builder.HasMany(a => a.Logs)
                .WithOne(l => l.App)
                .HasForeignKey(l => l.AppId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
