using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SignalRLab.Models
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        {
        }

        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

    }
}
