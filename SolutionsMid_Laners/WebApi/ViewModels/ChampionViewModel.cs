namespace WebApi.ViewModels
{
    public class ChampionViewModel
    {
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public List<SkillsChampionViewModel> SkillsChampions { get; set; }
    }
}
