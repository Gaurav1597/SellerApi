using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SellerApi.Models;

namespace SellerApi.Data
{
    public class SellerApiContext : DbContext
    {
        public SellerApiContext (DbContextOptions<SellerApiContext> options)
            : base(options)
        {
        }

        public DbSet<SellerApi.Models.Sellerslist> Sellerslist { get; set; }
    }
}
