using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FileRepository<T> where T : IFileFormattable<T>, new()
    {
        protected readonly string PATH;
        public FileRepository(string path)
        {
            PATH = path;
        }

        public T LoadSingle()
        {
            var line = File.ReadAllText(PATH);
            return new T().FromFileLine(line);
        }

        public void SaveSingle(T entity)
        {
            var line = entity.ForFileLine();
            File.WriteAllText(PATH, line);
        }

        public IList<T> LoadMultiple()
        {
            var lines = File.ReadAllLines(PATH);
            var data = new List<T>();
            lines.ToList().ForEach(l => data.Add(new T().FromFileLine(l)));

            return data;
        }

        public void SaveMultiple(IList<T> entities)
        {
            var lines = entities.Select(e => e.ForFileLine());
            File.WriteAllLines(PATH, lines);
        }
    }
}
