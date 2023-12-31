﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AlexandrKondratevKt4120.Database.Helper;
using AlexandrKondratevKt4120.Models;

namespace AlexandrKondratevKt4120.Database.Configurations
{
        public class PrepodConfiguration : IEntityTypeConfiguration<Prepod>
        {
            private const string TableName = "Prepod";

            public void Configure(EntityTypeBuilder<Prepod> builder)
            {
                builder
                        .HasKey(p => p.PrepodId)
                        .HasName($"pk_(TableName)_PrepodId");

                builder.Property(p => p.PrepodId)
                    .ValueGeneratedOnAdd();

                builder.Property(p => p.PrepodId)
                    .HasColumnName("discipline_id")
                    .HasComment("Идентификатор преподавателя");

                builder.Property(p => p.PrepodName)
                    .IsRequired()
                    .HasColumnName("c_discipline_name")
                    .HasColumnType(ColumnType.String).HasMaxLength(100)
                    .HasComment("ФИО препода");
            }
        }
    }