using AutoMapper;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        public readonly IChampion _IChampion;
        public readonly IMapper _IMapper;

        public ChampionController(IChampion IChampion, IMapper IMapper)
        {
            _IChampion = IChampion;
            _IMapper = IMapper;
        }

        [HttpPost("/AdicionarChampion")]
        public async Task AdicionarChampion(ChampionViewModel champion)
        {
            var championMap = _IMapper.Map<Champion>(champion);
            await _IChampion.AdicionarChampion(championMap);
        }

        [HttpDelete("/ExcluirChampion")]
        public async Task Excluir(int idChampion)
        {
            await _IChampion.Excluir(new Champion { Id = idChampion });
        }

        [HttpGet("/BuscarChampion")]
        public async Task<ChampionViewModel> BuscarChampion(int idChampion)
        {
            var champion = await _IChampion.BuscarChampion(idChampion);
            var clienteMap = _IMapper.Map<ChampionViewModel>(champion);
            return clienteMap;
        }

        [HttpGet("/ListarChampions")]
        public async Task<List<ChampionViewModel>> ListarChampions()
        {
            var champion = await _IChampion.ListarChampions();
            var clienteMap = _IMapper.Map<List<ChampionViewModel>>(champion);
            return clienteMap;
        }
    }
}
