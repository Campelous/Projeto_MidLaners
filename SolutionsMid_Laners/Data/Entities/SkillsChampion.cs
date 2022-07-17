using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("SkillsChampion")]
    public class SkillsChampion
    {
        public int Id { get; set; }
        public string Passiva { get; set; }
        public string Skill_1 { get; set; }
        public string Skill_2 { get; set; }
        public string Skill_3 { get; set; }
        public string Skill_4 { get; set; }

        [ForeignKey("Champion")]
        
        [Column(Order = 1)]
        public int IdChampion { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
