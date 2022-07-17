using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IChampion: IGeneric<Champion>
    {
        Task AdicionarChampion(Champion Objeto);
        Task<Champion> BuscarChampion(int Id);
        Task<List<Champion>> ListarChampions();
    }
}
