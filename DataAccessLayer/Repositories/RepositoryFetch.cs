using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using DataAccessLayer.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RepositoryFetch : IRepositoryFetch
    {
        public async Task<IList<T>> GetFromApi<T>(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(responseContent);

            return result;
        }

        public IList<T> GetFromJson<T>(string path)
        {
            string data = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<List<T>>(data);

            return result;
        }
    }
}
