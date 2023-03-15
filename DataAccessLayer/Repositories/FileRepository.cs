using DataAccessLayer.IRepositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FileRepository
    {
        protected readonly string PATH;
        public FileRepository(string path)
        {
            PATH = path;
        }
    }
}
