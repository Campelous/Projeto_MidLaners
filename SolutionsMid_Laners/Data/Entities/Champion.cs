using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Champion")]
    public class Champion
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }

        [NotMapped]
        public List<SkillsChampion> SkillsChampions { get; set; }
    }
}
