using Atleta.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atleta.DAO
{
    class Context : DbContext
        {
            public DbSet<Model.Atleta> Atletas { get; set; }

    }
}
