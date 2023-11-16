using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using AlexandrKondratevKt4120;
using AlexandrKondratevKt4120.Database;
using AlexandrKondratevKt4120.Interfaces.DisciplineInterfaces;
using AlexandrKondratevKt4120.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace alexandr_kondratev_kt_41_20.Tests
{
    public class DisciplineIntegrationTests
    {
        public readonly DbContextOptions<DisciplineDbContext> _dbContextOptions;

        public DisciplineIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DisciplineDbContext>()
                .UseInMemoryDatabase(databaseName: "student2")
                .Options;
        }

        [Fact]
        public async Task GetDisciplinesAsync_KT4120()
        {
            // Arrange
            var ctx = new DisciplineDbContext(_dbContextOptions);
            var discService = new DisciplineServices(ctx);
            var disc = new List<Discipline>
            {
                new Discipline
                {
                    DisciplineId = 1,
                    DisciplineName = "Психология",
                    DisciplineNagruzka = 35,
                    PrepodId = 1
                },
                new Discipline
                {
                    DisciplineId = 2,
                    DisciplineName = "Философия",
                    DisciplineNagruzka = 40,
                    PrepodId = 2
                },  
                new Discipline
                {
                    DisciplineId = 3,
                    DisciplineName = "Иностранный язык",
                    DisciplineNagruzka = 24,
                    PrepodId = 1
                }
            };
            await ctx.Set<Discipline>().AddRangeAsync(disc);

            var prepod = new List<Prepod>
            {
                new Prepod
                {
                    PrepodId = 1,
                    PrepodName = "Романов Роман Романович"
                },
                new Prepod
                {
                    PrepodId = 2,
                    PrepodName = "Васильев Василий Васильевич"
                }
            };
            await ctx.Set<Prepod>().AddRangeAsync(prepod);

            await ctx.SaveChangesAsync();

            // Act
            var filter = new AlexandrKondratevKt4120.Filters.DisciplineFilter.DisciplineFilter
            {
                DisciplinePrepod = "Романов Роман Романович"
            };
            var disciplineResult = await discService.GetDisciplinesAsync(filter, CancellationToken.None);

            // Assert
            Assert.Single(disciplineResult);

        }
    }
}