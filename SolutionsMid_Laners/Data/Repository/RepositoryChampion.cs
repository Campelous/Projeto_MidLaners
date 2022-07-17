using Data.Config;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryChampion: RepositoryGeneric<Champion>, IChampion
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public RepositoryChampion()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task AdicionarChampion(Champion Objeto)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {
                await data.Set<Champion>().AddAsync(Objeto);
                await data.SaveChangesAsync();

                if (Objeto.SkillsChampions.Any())
                {
                    Objeto.SkillsChampions.ForEach(a => a.IdChampion = Objeto.Id);
                    await data.Set<SkillsChampion>().AddRangeAsync(Objeto.SkillsChampions);
                    await data.SaveChangesAsync();
                }
            }
        }

        public async Task<Champion> BuscarChampion(int Id)
        {
            using (var data = new ContextBase(_optionsBuilder))
            {

                var champion = await data.Champion.FindAsync(Id);
                if (champion != null)
                {
                    var skillsChampions = await data.SkillsChampion.Where(a => a.IdChampion.Equals(Id)).ToListAsync();

                    if (skillsChampions.Any())
                        champion.SkillsChampions = skillsChampions;

                    return champion;
                }
                else return null;
            }
        }

        public async Task<List<Champion>> ListarChampions()
        {
            var listaTarefas = new List<Champion>();

            using (var data = new ContextBase(_optionsBuilder))
            {
                var championsComSkill = await (from CH in data.Champion
                                            join SCH in data.SkillsChampion on CH.Id equals SCH.IdChampion
                                            select new
                                            {
                                                Id = CH.Id,
                                                Nome = CH.Nome,
                                                IdSkillsChampion = SCH.Id,
                                                Passiva = SCH.Passiva,
                                                SCH.IdChampion,
                                                Skill_1 = SCH.Skill_1,
                                                Skill_2 = SCH.Skill_2,
                                                Skill_3 = SCH.Skill_3,
                                                Skill_4 = SCH.Skill_4,
                                            }).ToListAsync();

                var lista = championsComSkill.Select(a => new { Id = a.Id, Nome = a.Nome }).Distinct().ToList();

                var listaCompleta = lista.Select(a => new Champion
                {
                    Id = a.Id,
                    Nome = a.Nome,
                    SkillsChampions =
        championsComSkill.Where(x => x.IdChampion == a.Id)
        .Select(x => new SkillsChampion { Id = x.IdSkillsChampion, Passiva = x.Passiva, IdChampion = x.IdChampion, Skill_1 = x.Skill_1, Skill_2 = x.Skill_2, Skill_3 = x.Skill_3, Skill_4 = x.Skill_4 }).ToList()
                });

                if (listaCompleta.Any())
                    listaTarefas.AddRange(listaCompleta);
            }

            return listaTarefas;
        }
    }
}
