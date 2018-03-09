using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolScan.Models.Configuration;

namespace ToolScan.Models
{
    public class ToolContext:DbContext
    {
        public ToolContext() : base("tool") { }
        public ToolContext(string connectionString) : base(connectionString) { }
        public IDbSet<ToolsEntity> Tools { get; set; }
        public IDbSet<ToolLogEntity> ToolLog { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Configurations.Add(new ToolConfig());
            modelBuilder.Configurations.Add(new ToolLogConfig());
        }
    }
}
