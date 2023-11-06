using Microsoft.EntityFrameworkCore;
using Proektniy.Database;
using Proektniy.Filters.DisciplineFilter;
using Proektniy.Models;

namespace Proektniy.Interfaces.DisciplineInterfaces
{
        public interface IDisciplineService
        {
            public Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken);
        }

    public class DisciplineServices : IDisciplineService
        {
            public Task<Discipline[]> GetDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken = default)
            {
            var grades = _dbContext.Set<Discipline>().Where( d=>
                           d.Prepod.PrepodName == filter.DisciplinePrepod && d.DisciplineNagruzka > 20 && d.DisciplineNagruzka < 30 ==
                           filter.DisciplineNagruzka > 20 && filter.DisciplineNagruzka < 30).ToArrayAsync(cancellationToken);
            return grades;
        }

            private readonly DbContext _dbContext;

            public DisciplineServices(DisciplineDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        }
}
