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
                var disc = _dbContext.Set<Discipline>().Where(d => d.DisciplineName == filter.DisciplineName).Where(d => d.DisciplinePrepod == filter.DisciplinePrepod).Where(d => d.DisciplineNagruzka > 20 && d.DisciplineNagruzka < 30 == filter.DisciplineNagruzka > 20 && filter.DisciplineNagruzka < 30).ToArrayAsync(cancellationToken);
                return disc;
            }

            private readonly DbContext _dbContext;

            public DisciplineServices(DisciplineDbContext dbContext)
            {
                _dbContext = dbContext;
            }
        }
}
