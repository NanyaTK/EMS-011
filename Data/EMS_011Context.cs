using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS_011.Models;

namespace EMS_011.Data
{
    public class EMS_011Context : DbContext
    {
        public EMS_011Context (DbContextOptions<EMS_011Context> options)
            : base(options)
        {
        }

        public DbSet<EMS_011.Models.PurchaseReports> PurchaseReports { get; set; } = default!;
    }
}
