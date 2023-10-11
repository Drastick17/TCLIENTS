using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TCLIENTS.Models;

namespace TCLIENTS.Data
{
    public class TCLIENTSContext : DbContext
    {
        public TCLIENTSContext (DbContextOptions<TCLIENTSContext> options)
            : base(options)
        {
        }

        public DbSet<TCLIENTS.Models.TCliente> TCliente { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TCliente>().ToTable(tb => tb.HasTrigger("TGR_AuditClienteDelete"));
            builder.Entity<TCliente>().ToTable(tb => tb.HasTrigger("TGR_AuditClienteInsert"));
            builder.Entity<TCliente>().ToTable(tb => tb.HasTrigger("TGR_AuditClienteUpdate"));
        }
    }
}
