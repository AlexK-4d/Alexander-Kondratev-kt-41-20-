using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.Text.RegularExpressions;

namespace AlexandrKondratevKt4120.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string DisciplineName { get; set; }
        public int DisciplineNagruzka { get; set; }

        public int PrepodId { get; set; }

        public Prepod? Prepod { get; set; }

    }
}
