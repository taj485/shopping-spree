using ShoppingSpree.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Data.Services
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductsModel> Products { get; set; }
    };
}
