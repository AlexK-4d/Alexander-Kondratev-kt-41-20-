using Microsoft.EntityFrameworkCore;
using AlexandrKondratevKt4120.Database;
using AlexandrKondratevKt4120.Filters.DisciplineFilter;
using AlexandrKondratevKt4120.Models;

namespace AlexandrKondratevKt4120.Interfaces.DisciplineInterfaces
{
        public interface IDisciplineService
        {
            public Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken);
        }

    public class DisciplineServices : IDisciplineService
        {
            public Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken = default)
            {
            var grades = _dbContext.Set<Discipline>().Where(d =>
                           d.PrepodId == filter.PrepodId &&
                           d.DisciplineNagruzka > filter.DisciplineNagruzkaMore && d.DisciplineNagruzka <
                           filter.DisciplineNagruzkaLess).Select(
               d => new Discipline
               {
                   DisciplineId = d.DisciplineId,
                   DisciplineName = d.DisciplineName,
                   DisciplineNagruzka = d.DisciplineNagruzka,
                   PrepodId = d.PrepodId
               }).ToArrayAsync(cancellationToken);
            return grades;
        }

            private readonly DbContext _dbContext;

            public DisciplineServices(DisciplineDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        }
}
