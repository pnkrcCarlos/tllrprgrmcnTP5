using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ2
{
    class EJ2Context : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        private readonly string schema;

        public EJ2Context(string schema) : base("AppDatabaseConnectionString")
        {
            this.schema = schema;
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.HasDefaultSchema(this.schema);
            base.OnModelCreating(builder);
        }
    }
}
