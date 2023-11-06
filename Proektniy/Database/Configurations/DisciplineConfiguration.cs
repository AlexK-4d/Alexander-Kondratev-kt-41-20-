using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proektniy.Database.Helper;
using Proektniy.Models;

namespace Proektniy.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "Discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                    .HasKey(p => p.DisciplineId)
                    .HasName($"pk_(TableName)_DisciplineId");

            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор дисциплины");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Наименование дисциплины");

            builder.Property(p => p.DisciplineNagruzka)
                .IsRequired()
                .HasColumnName("c_discipline_nagruzka")
                .HasColumnType(ColumnType.Int).HasMaxLength(100)
                .HasComment("Нагрузка дисциплины");

            builder.ToTable(TableName)
                .HasOne(p => p.Prepod)
                .WithMany(p => p.Disciplines)
                .HasForeignKey(p => p.PrepodId)
                .HasConstraintName("fk_f_prepod_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.PrepodId, $"idx_{TableName}_fk_f_prepod_id");

            builder.Navigation(p => p.Prepod)
                .AutoInclude();
        }
    }
}
