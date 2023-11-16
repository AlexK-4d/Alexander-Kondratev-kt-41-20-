using Microsoft.AspNetCore.Mvc;
using AlexandrKondratevKt4120.Filters.DisciplineFilter;
using AlexandrKondratevKt4120.Interfaces.DisciplineInterfaces;

namespace AlexandrKondratevKt4120.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class DisciplinesController : ControllerBase
        {
            private readonly ILogger<DisciplinesController> _logger;
            private readonly IDisciplineService _disciplineService;

            public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplineService disciplineService)
            {
                _logger = logger;
                _disciplineService = disciplineService;
            }


            [HttpPost(Name = "GetListOfDisciplinesByPrepodAndNagruzka")]
            public async Task<IActionResult> GetAllDisciplinesAsync(DisciplineFilter filter, CancellationToken cancellationToken = default)
            {
                var grades = await _disciplineService.GetDisciplinesAsync(filter, cancellationToken);
                return Ok(grades);
            }
        }
    }