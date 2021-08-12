using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Buku.Models
{
    public class BukuDatabaseSettings:IBukuDatabaseSettings
    {
        public string BukuCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBukuDatabaseSettings
    {
        public string BukuCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
