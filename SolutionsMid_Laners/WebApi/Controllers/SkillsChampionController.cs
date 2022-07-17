using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsChampionController : ControllerBase
    {
        public readonly ISkillsChampion _ISkillsChampion;

        public SkillsChampionController(ISkillsChampion ISkillsChampion)
        {
            _ISkillsChampion = ISkillsChampion;
        }

        [HttpPost("/AdicionarSkill")]
        public async Task AdicionarSkill(SkillsChampion skillsChampion)
        {
            await _ISkillsChampion.Adicionar(skillsChampion);
        }

        [HttpPut("/AtualizarSkill")]
        public async Task AtualizarSkill(SkillsChampion skillsChampion)
        {
            await _ISkillsChampion.Atualizar(skillsChampion);
        }

        [HttpDelete("/ExcluirSkill")]
        public async Task ExcluirSkill(SkillsChampion skillsChampion)
        {
            await _ISkillsChampion.Excluir(skillsChampion);
        }

        [HttpGet("/BuscarSkillsChampion")]
        public async Task<SkillsChampion> BuscarSkillsChampion(int idSkillsChampion)
        {
            return await _ISkillsChampion.BuscaPorCodigo(idSkillsChampion);
        }


        [HttpGet("/ListarSkills")]
        public async Task<List<SkillsChampion>> ListarSkills()
        {
            return await _ISkillsChampion.ListarTudo();
        }
    }
}
