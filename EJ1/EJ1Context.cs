using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EJ1
{
    class EJ1Context : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }

        private readonly string schema;

        public EJ1Context(string schema) : base("AppDatabaseConnectionString")
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
