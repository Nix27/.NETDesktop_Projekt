using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IRepositoryFetch
    {
        Task<IList<T>> GetFromApi<T>(string url);
        IList<T> GetFromJson<T>(string path);
        IList<Player> GetPlayersBasedOnFifaCode(IList<Match> matches, string selectedRepresentation);
    }
}
