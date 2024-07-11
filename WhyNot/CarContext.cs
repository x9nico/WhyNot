using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace WhyNot
{
    internal class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
